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
        public bool IsWorking { get; private set; }

        public Command StartCommand { get; private set; }
        public Command StopCommand { get; private set; }

        public event Action ClearMessageEventHandler;
        public event Action<string> AddMessageEventHandler;

        public CrawlPanelViewModel()
        {
            StartCommand = new Command(Start, CanStart);
            StopCommand = new Command(Stop, CanStop);
        }

        public void Start(object arg)
        {
            IsWorking = true;

            Task.Run(Crawl);
        }

        public void Stop(object arg)
        {
            IsWorking = false;
            AddMessage("正在停止");
        }

        public void Crawl()
        {
            ClearMessage();
            AddMessage("开始爬取");

            StockDbContext context = new StockDbContext();
            var taskList = context.CrawlTask.Where(x => x.State == CrawlTaskState.Created || x.State == CrawlTaskState.Doing)
                .Include(x => x.Stock).ToList();
            AddMessage($"当前有{taskList.Count}个任务待完成");

            HistoryTradeCrawler crawler = new HistoryTradeCrawler();

            foreach (var crawlTask in taskList)
            {
                int year = crawlTask.Stock.ListingDate.Year;
                int season = (crawlTask.Stock.ListingDate.Month - 1) / 3 + 1;
                bool completed = false;

                while (IsWorking)
                {
                    if (year >= DateTime.Now.Year
                        && season >= ((DateTime.Now.Month - 1) / 3 + 1))
                    {
                        completed = true;
                        break;
                    }

                    crawler.Open(crawlTask.Stock, year, season);
                    Task.Delay(1000).Wait();
                    var records = crawler.Get();

                    if (records != null && records.Length > 0)
                    {
                        context.DayTradeRecord.AddRange(records);
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
                    crawlTask.State = CrawlTaskState.Done;
                    context.SaveChanges();
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

        public bool CanStart(object arg) => !IsWorking;
        public bool CanStop(object arg) => IsWorking;

        private void ClearMessage() => ClearMessageEventHandler?.Invoke();
        private void AddMessage(string msg) => AddMessageEventHandler?.Invoke(msg);
    }
}
