using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCommonExtension;
using StockApp.Crawler;
using StockApp.DB;
using StockApp.DB.Models;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace StockApp.ViewModels
{
    public class CrawlPanelViewModel
    {
        private StockDbContext context = new StockDbContext();
        private List<CrawlTask> PendingTaskList = new List<CrawlTask>();
        private object getTaskLock = new object();
        private object saveLock = new object();

        public bool IsWorking { get; private set; }
        public int ThreadCount { get; set; } = 7;
        public CrawlTaskType CrawlTaskType { get; set; } = CrawlTaskType.CrawlDayTradeRecord;

        public Command StartCommand { get; private set; }
        public Command StopCommand { get; private set; }

        public event Action ClearMessageEventHandler;
        public event Action<string> AddMessageEventHandler;

        public CrawlPanelViewModel()
        {
            StartCommand = new Command(Start, CanStart);
            StopCommand = new Command(Stop, CanStop);
        }

        private async void Start(object arg)
        {
            IsWorking = true;

            ClearMessage();

            switch (CrawlTaskType)
            {
                case CrawlTaskType.CrawlDayTradeRecord:
                    CrawlDayTradeRecord();
                    break;
                case CrawlTaskType.CrawlFinancialSummary:
                    await CrawlFinancialSummary();
                    break;
                case CrawlTaskType.CrawlFinancialBrief:
                    await CrawlFinancialBrief();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void Stop(object arg)
        {
            IsWorking = false;
            AddMessage("正在停止");
        }

        private bool CanStart(object arg) => !IsWorking;

        private bool CanStop(object arg) => IsWorking;

        private void CrawlDayTradeRecord()
        {
            PendingTaskList = context.CrawlTask.Where(x => x.State != CrawlTaskState.Done && x.Type == CrawlTaskType.CrawlDayTradeRecord)
                .Include(x => x.Stock).ToList();

            AddMessage($"当前有{PendingTaskList.Count}个任务待完成");

            for (int i = 0; i < ThreadCount; i++)
            {
                Task.Run(CrawlDayTradeRecordThread);
            }
        }

        private void CrawlDayTradeRecordThread()
        {
            AddMessage("开始爬取");

            HistoryTradeCrawler crawler = new HistoryTradeCrawler();

            while (true)
            {
                CrawlTask crawlTask;

                lock (getTaskLock)
                {
                    crawlTask = PendingTaskList.FirstOrDefault(x => x.State == CrawlTaskState.Created);

                    if (crawlTask == null)
                    {
                        AddMessage("全部爬取完成");
                        break;
                    }

                    crawlTask.State = CrawlTaskState.Doing;
                }

                int year = crawlTask.Stock.ListingDate.Year;
                int season = (crawlTask.Stock.ListingDate.Month - 1) / 3 + 1;
                bool completed = false;
                List<DayTradeRecord> recordList = new List<DayTradeRecord>();

                while (IsWorking)
                {
                    if (year >= DateTime.Now.Year
                        && season >= ((DateTime.Now.Month - 1) / 3 + 1))
                    {
                        completed = true;
                        break;
                    }

                    crawler.Open(crawlTask.Stock, year, season);
                    Task.Delay(100).Wait();
                    var records = crawler.Get();

                    if (records != null && records.Length > 0)
                    {
                        recordList.AddRange(records);
                    }

                    if (season == 4)
                    {
                        season = 1;
                        year++;
                    }
                    else
                    {
                        season++;
                    }
                }

                if (completed)
                {
                    lock (saveLock)
                    {
                        context.DayTradeRecord.AddRange(recordList);
                        crawlTask.State = CrawlTaskState.Done;
                        context.SaveChanges();
                    }

                    AddMessage($"{crawlTask.Stock.Number} {crawlTask.Stock.Name} 爬取完成");
                }

                if (!IsWorking)
                {
                    break;
                }
            }

            crawler.Dispose();
            AddMessage("爬取已停止");
        }

        private async Task CrawlFinancialSummary()
        {
            var stocks = await context.Stock.AsNoTracking().ToListAsync();
            int newCount = 0;

            foreach(var stock in stocks)
            {
                if (!context.CrawlTask.Any(x => x.StockID == stock.ID && x.Type == CrawlTaskType.CrawlFinancialSummary))
                {
                    CrawlTask task = new CrawlTask()
                    {
                        StockID = stock.ID,
                        State = CrawlTaskState.Created,
                        Type = CrawlTaskType.CrawlFinancialSummary
                    };
                    context.CrawlTask.Add(task);
                    newCount++;
                }
            }

            if (newCount > 0)
            {
                await context.SaveChangesAsync();
                AddMessage($"新建{newCount}条爬取任务");
            }

            PendingTaskList = context.CrawlTask.Where(x => x.State != CrawlTaskState.Done && x.Type == CrawlTaskType.CrawlFinancialSummary)
                .Include(x => x.Stock).ToList();

            AddMessage($"当前有{PendingTaskList.Count}个任务待完成");

            for (int i = 0; i < ThreadCount; i++)
            {
                Task.Run(CrawlFinancialSummaryThread);
            }
        }

        private void CrawlFinancialSummaryThread()
        {
            AddMessage("开始爬取");

            FinancialSummaryCrawler crawler = new FinancialSummaryCrawler();

            while (true)
            {
                CrawlTask crawlTask;

                lock (getTaskLock)
                {
                    crawlTask = PendingTaskList.FirstOrDefault(x => x.State == CrawlTaskState.Created);

                    if (crawlTask == null)
                    {
                        AddMessage("全部爬取完成");
                        break;
                    }

                    crawlTask.State = CrawlTaskState.Doing;
                }

                crawler.Open(crawlTask.Stock, TimeRange.Season);
                Task.Delay(100).Wait();
                SeasonFinancialSummary[] summarys1 = crawler.Get<SeasonFinancialSummary>();
                crawler.Open(crawlTask.Stock, TimeRange.Year);
                Task.Delay(100).Wait();
                YearFinancialSummary[] summary2 = crawler.Get<YearFinancialSummary>();

                lock(saveLock)
                {
                    if (summarys1 != null)
                    {
                        context.SeasonFinancialSummary.AddRange(summarys1);
                    }

                    if (summary2 != null)
                    {
                        context.YearFinancialSummary.AddRange(summary2);
                    }

                    crawlTask.State = CrawlTaskState.Done;
                    context.SaveChanges();
                }

                AddMessage($"{crawlTask.Stock.Number} {crawlTask.Stock.Name} 爬取完成");

                if (!IsWorking)
                {
                    break;
                }
            }

            crawler.Dispose();
            AddMessage("爬取已停止");
        }

        private async Task CrawlFinancialBrief()
        {
            var stocks = await context.Stock.AsNoTracking().ToListAsync();
            int newCount = 0;

            foreach (var stock in stocks)
            {
                if (!context.CrawlTask.Any(x => x.StockID == stock.ID && x.Type == CrawlTaskType.CrawlFinancialBrief))
                {
                    CrawlTask task = new CrawlTask()
                    {
                        StockID = stock.ID,
                        State = CrawlTaskState.Created,
                        Type = CrawlTaskType.CrawlFinancialBrief
                    };
                    context.CrawlTask.Add(task);
                    newCount++;
                }
            }

            if (newCount > 0)
            {
                await context.SaveChangesAsync();
                AddMessage($"新建{newCount}条爬取任务");
            }

            PendingTaskList = context.CrawlTask.Where(x => x.State != CrawlTaskState.Done && x.Type == CrawlTaskType.CrawlFinancialBrief)
                .Include(x => x.Stock).ToList();

            AddMessage($"当前有{PendingTaskList.Count}个任务待完成");

            for (int i = 0; i < ThreadCount; i++)
            {
                Task.Run(CrawlFinancialBriefThread);
            }
        }

        private void CrawlFinancialBriefThread()
        {
            AddMessage("开始爬取");

            FinancialBriefCrawler crawler = new FinancialBriefCrawler();

            while (true)
            {
                CrawlTask crawlTask;

                lock (getTaskLock)
                {
                    crawlTask = PendingTaskList.FirstOrDefault(x => x.State == CrawlTaskState.Created);

                    if (crawlTask == null)
                    {
                        AddMessage("全部爬取完成");
                        break;
                    }

                    crawlTask.State = CrawlTaskState.Doing;
                }

                crawler.Open(crawlTask.Stock, TimeRange.Season);
                Task.Delay(100).Wait();
                SeasonFinancialBrief[] summarys1 = crawler.Get<SeasonFinancialBrief>();
                crawler.Open(crawlTask.Stock, TimeRange.Year);
                Task.Delay(100).Wait();
                YearFinancialBrief[] summary2 = crawler.Get<YearFinancialBrief>();

                lock (saveLock)
                {
                    if (summarys1 != null)
                    {
                        context.SeasonFinancialBrief.AddRange(summarys1);
                    }

                    if (summary2 != null)
                    {
                        context.YearFinancialBrief.AddRange(summary2);
                    }

                    crawlTask.State = CrawlTaskState.Done;
                    context.SaveChanges();
                }

                AddMessage($"{crawlTask.Stock.Number} {crawlTask.Stock.Name} 爬取完成");

                if (!IsWorking)
                {
                    break;
                }
            }

            crawler.Dispose();
            AddMessage("爬取已停止");
        }

        private void ClearMessage() => ClearMessageEventHandler?.Invoke();

        private void AddMessage(string msg) => AddMessageEventHandler?.Invoke(msg);
    }
}
