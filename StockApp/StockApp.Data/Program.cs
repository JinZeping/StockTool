using System;
using StockApp.DB;
using StockApp.DB.Models;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StockApp.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            AddYearChangeRateSummarys();
        }

        public static void AddExchanges()
        {
            StockDbContext context = new StockDbContext();

            Exchange shanghai = new Exchange()
            {
                Name = "上海证券交易所",
                NameAbbr = "上证"
            };

            Exchange shenzhen = new Exchange()
            {
                Name = "深圳证券交易所",
                NameAbbr = "深证"
            };

            context.Exchange.Add(shanghai);
            context.Exchange.Add(shenzhen);
            context.SaveChanges();
        }

        public static void AddStocks()
        {
            StockDbContext context = new StockDbContext();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("GB2312");

            Exchange shanghai = context.Exchange.First(x => x.NameAbbr == "上证");
            Exchange shenzhen = context.Exchange.First(x => x.NameAbbr == "深证");

            using (StreamReader reader = new StreamReader(@"E:\GitHub\StockTool\Document\沪主板A股.csv", encoding))
            {
                string line = reader.ReadLine();

                while (true)
                {
                    line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        break;
                    }

                    string[] array = line.Split(',');

                    Stock stock = new Stock()
                    {
                        ExchangeID = shanghai.ID,
                        Name = array[3].Trim(),
                        Number = array[2].Trim(),
                        Board = "A股",
                        ListingDate = DateTime.Parse(array[4])
                    };

                    context.Add(stock);
                }
            }

            using (StreamReader reader = new StreamReader(@"E:\GitHub\StockTool\Document\沪主板B股.csv", encoding))
            {
                string line = reader.ReadLine();

                while (true)
                {
                    line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        break;
                    }

                    string[] array = line.Split(',');

                    Stock stock = new Stock()
                    {
                        ExchangeID = shanghai.ID,
                        Name = array[3].Trim(),
                        Number = array[2].Trim(),
                        Board = "B股",
                        ListingDate = DateTime.Parse(array[4])
                    };

                    context.Add(stock);
                }
            }

            using (StreamReader reader = new StreamReader(@"E:\GitHub\StockTool\Document\沪科创板.csv", encoding))
            {
                string line = reader.ReadLine();

                while (true)
                {
                    line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        break;
                    }

                    string[] array = line.Split(',');

                    Stock stock = new Stock()
                    {
                        ExchangeID = shanghai.ID,
                        Name = array[3].Trim(),
                        Number = array[2].Trim(),
                        Board = "科创板",
                        ListingDate = DateTime.Parse(array[4])
                    };

                    context.Add(stock);
                }
            }

            using (StreamReader reader = new StreamReader(@"E:\GitHub\StockTool\Document\深A股列表.txt", encoding))
            {
                string line = reader.ReadLine();

                while (true)
                {
                    line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        break;
                    }

                    string[] array = line.Split('\t');

                    Stock stock = new Stock()
                    {
                        ExchangeID = shenzhen.ID,
                        Name = array[5].Trim(),
                        Number = array[4].Trim(),
                        Board = "A股",
                        ListingDate = DateTime.Parse(array[6])
                    };

                    context.Add(stock);
                }
            }

            using (StreamReader reader = new StreamReader(@"E:\GitHub\StockTool\Document\深B股列表.txt", encoding))
            {
                string line = reader.ReadLine();

                while (true)
                {
                    line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        break;
                    }

                    string[] array = line.Split('\t');

                    Stock stock = new Stock()
                    {
                        ExchangeID = shenzhen.ID,
                        Name = array[10].Trim(),
                        Number = array[9].Trim(),
                        Board = "B股",
                        ListingDate = DateTime.Parse(array[11])
                    };

                    context.Add(stock);
                }
            }

            context.SaveChanges();
        }

        public static void AddCrawlTasks()
        {
            StockDbContext context = new StockDbContext();
            List<int> stockIDList = context.Stock.Select(x => x.ID).ToList();

            foreach (var stockID in stockIDList)
            {
                CrawlTask task = new CrawlTask()
                {
                    Type = CrawlTaskType.CrawlDayTradeRecord,
                    State = CrawlTaskState.Created,
                    StockID = stockID
                };

                context.CrawlTask.Add(task);
            }

            context.SaveChanges();
        }

        public static void EditDayTradeRecord()
        {
            StockDbContext context = new StockDbContext();
            Console.WriteLine($"正在查询");

            var records = context.DayTradeRecord.Where(x => x.Begin == -99999999.99m
                || x.End == -99999999.99m
                || x.Max == -99999999.99m
                || x.Min == -99999999.99m
                || x.Change == -99999999.99m
                || x.ChangeRate == -99999999.99m
                || x.TradeHand == -99999999.99m
                || x.TradeAmount == -99999999.99m
                || x.Amplitude == -99999999.99m
                || x.TurnoverRate == -99999999.99m)
                .ToList();

            Console.WriteLine($"查询到{records.Count()}条数据");

            foreach (var record in records)
            {
                if (record.Begin == -99999999.99m)
                {
                    record.Begin = null;
                }

                if (record.End == -99999999.99m)
                {
                    record.End = null;
                }

                if (record.Max == -99999999.99m)
                {
                    record.Max = null;
                }

                if (record.Min == -99999999.99m)
                {
                    record.Min = null;
                }

                if (record.Change == -99999999.99m)
                {
                    record.Change = null;
                }

                if (record.ChangeRate == -99999999.99m)
                {
                    record.ChangeRate = null;
                }

                if (record.TradeHand == -99999999.99m)
                {
                    record.TradeHand = null;
                }

                if (record.TradeAmount == -99999999.99m)
                {
                    record.TradeAmount = null;
                }

                if (record.Amplitude == -99999999.99m)
                {
                    record.Amplitude = null;
                }

                if (record.TurnoverRate == -99999999.99m)
                {
                    record.TurnoverRate = null;
                }
            }

            context.SaveChanges();
            Console.WriteLine("Completed");
        }

        public static void AddMonthSeasonYearTradeRecord()
        {
            Log.Debug("获取股票列表");

            List<CrawlTask> taskList;

            using (StockDbContext context = new StockDbContext())
            {
                var stockList = context.Stock.AsNoTracking().ToList();

                foreach (var stock in stockList)
                {
                    if (!context.CrawlTask.Any(x => x.StockID == stock.ID && x.Type == CrawlTaskType.MonthSeasonYearTradeRecord))
                    {
                        CrawlTask t = new CrawlTask()
                        {
                            StockID = stock.ID,
                            Type = CrawlTaskType.MonthSeasonYearTradeRecord,
                            State = CrawlTaskState.Created
                        };
                        context.CrawlTask.Add(t);
                    }
                }

                context.SaveChanges();
                taskList = context.CrawlTask.Where(x => x.Type == CrawlTaskType.MonthSeasonYearTradeRecord && x.State != CrawlTaskState.Done)
                    .Include(x => x.Stock).AsNoTracking().ToList();
            }

            for (int i = 0; i < taskList.Count; i++)
            {
                var task = taskList[i];
                Log.Debug($"{task.Stock.Number}  {task.Stock.Name}  {i}/{taskList.Count}");

                using (StockDbContext context = new StockDbContext())
                {

                    List<DayTradeRecord> dayList = context.DayTradeRecord.Where(x => x.StockID == task.StockID).AsNoTracking().ToList();
                    List<MonthTradeRecord> monthList = new List<MonthTradeRecord>();
                    List<SeasonTradeRecord> seasonList = new List<SeasonTradeRecord>();
                    List<YearTradeRecord> yearList = new List<YearTradeRecord>();

                    if (dayList.Count == 0)
                    {
                        continue;
                    }

                    DateTime start = dayList.Min(x => x.Date);
                    DateTime stop = dayList.Max(x => x.Date);

                    start = new DateTime(start.Year, start.Month, 1);
                    stop = new DateTime(stop.Year, stop.Month, 1);

                    DateTime monthBegin = start;

                    while (true)
                    {
                        if (monthBegin > stop)
                        {
                            break;
                        }

                        DateTime monthEnd = monthBegin.AddMonths(1).AddDays(-1);
                        List<DayTradeRecord> dayList2 = dayList.Where(x => x.Date >= monthBegin && x.Date <= monthEnd)
                            .OrderBy(x => x.Date).ToList();

                        if (dayList2.Count != 0)
                        {
                            MonthTradeRecord record = new MonthTradeRecord()
                            {
                                StockID = task.StockID,
                                Date = monthBegin,
                                Begin = dayList2.First().Begin,
                                End = dayList2.Last().End,
                                Min = dayList2.Min(x => x.Min),
                                Max = dayList2.Max(x => x.Max),
                                TradeHand = dayList2.Sum(x => x.TradeHand),
                                TradeAmount = dayList2.Sum(x => x.TradeAmount),
                                TurnoverRate = dayList2.Sum(x => x.TurnoverRate)
                            };

                            if (monthList.Count == 0)
                            {
                                record.Change = record.End - record.Begin;
                                record.ChangeRate = record.Change / record.Begin * 100;
                                record.Amplitude = (record.Max - record.Min) / record.Begin * 100;
                            }
                            else
                            {
                                var last = monthList.Last();
                                record.Change = record.End - last.End;
                                record.ChangeRate = record.Change / last.End * 100;
                                record.Amplitude = (record.Max - record.Min) / last.End * 100;
                            }

                            monthList.Add(record);
                        }

                        monthBegin = monthBegin.AddMonths(1);
                    }


                    start = new DateTime(start.Year, (start.Month - 1) / 3 * 3 + 1, 1);
                    stop = new DateTime(stop.Year, (stop.Month - 1) / 3 * 3 + 1, 1);

                    monthBegin = start;

                    while (true)
                    {
                        if (monthBegin > stop)
                        {
                            break;
                        }

                        DateTime monthEnd = monthBegin.AddMonths(3);
                        List<MonthTradeRecord> monthList2 = monthList.Where(x => x.Date >= monthBegin && x.Date < monthEnd)
                            .OrderBy(x => x.Date).ToList();

                        if (monthList2.Count != 0)
                        {
                            SeasonTradeRecord record = new SeasonTradeRecord()
                            {
                                StockID = task.StockID,
                                Date = monthBegin,
                                Begin = monthList2.First().Begin,
                                End = monthList2.Last().End,
                                Min = monthList2.Min(x => x.Min),
                                Max = monthList2.Max(x => x.Max),
                                TradeHand = monthList2.Sum(x => x.TradeHand),
                                TradeAmount = monthList2.Sum(x => x.TradeAmount),
                                TurnoverRate = monthList2.Sum(x => x.TurnoverRate)
                            };

                            if (seasonList.Count == 0)
                            {
                                record.Change = record.End - record.Begin;
                                record.ChangeRate = record.Change / record.Begin * 100;
                                record.Amplitude = (record.Max - record.Min) / record.Begin * 100;
                            }
                            else
                            {
                                var last = seasonList.Last();
                                record.Change = record.End - last.End;
                                record.ChangeRate = record.Change / last.End * 100;
                                record.Amplitude = (record.Max - record.Min) / last.End * 100;
                            }

                            seasonList.Add(record);
                        }

                        monthBegin = monthBegin.AddMonths(3);
                    }


                    start = new DateTime(start.Year, 1, 1);
                    stop = new DateTime(stop.Year, 1, 1);

                    monthBegin = start;

                    while (true)
                    {
                        if (monthBegin > stop)
                        {
                            break;
                        }

                        DateTime monthEnd = monthBegin.AddYears(1);
                        List<SeasonTradeRecord> seasonList2 = seasonList.Where(x => x.Date >= monthBegin && x.Date < monthEnd)
                            .OrderBy(x => x.Date).ToList();

                        if (seasonList2.Count != 0)
                        {
                            YearTradeRecord record = new YearTradeRecord()
                            {
                                StockID = task.StockID,
                                Date = monthBegin,
                                Begin = seasonList2.First().Begin,
                                End = seasonList2.Last().End,
                                Min = seasonList2.Min(x => x.Min),
                                Max = seasonList2.Max(x => x.Max),
                                TradeHand = seasonList2.Sum(x => x.TradeHand),
                                TradeAmount = seasonList2.Sum(x => x.TradeAmount),
                                TurnoverRate = seasonList2.Sum(x => x.TurnoverRate)
                            };

                            if (yearList.Count == 0)
                            {
                                record.Change = record.End - record.Begin;
                                record.ChangeRate = record.Change / record.Begin * 100;
                                record.Amplitude = (record.Max - record.Min) / record.Begin * 100;
                            }
                            else
                            {
                                var last = yearList.Last();
                                record.Change = record.End - last.End;
                                record.ChangeRate = record.Change / last.End * 100;
                                record.Amplitude = (record.Max - record.Min) / last.End * 100;
                            }

                            yearList.Add(record);
                        }

                        monthBegin = monthBegin.AddYears(1);
                    }

                    context.MonthTradeRecord.AddRange(monthList);
                    context.SeasonTradeRecord.AddRange(seasonList);
                    context.YearTradeRecord.AddRange(yearList);
                    task.State = CrawlTaskState.Done;
                    context.Attach<CrawlTask>(task).State = EntityState.Modified;

                    context.SaveChanges();
                }
            }

            Log.Debug("完成");
        }

        public static void AddYearChangeRateSummarys()
        {
            Log.Info("准备");

            StockDbContext context = new StockDbContext();

            DateTime startDate = context.YearTradeRecord.Min(x => x.Date);
            decimal maxChangeRate = context.YearTradeRecord.Where(x => x.ChangeRate != null).Max(x => x.ChangeRate.Value);
            DateTime endDate = new DateTime(2020, 1, 1);
            decimal[] stepArray = new decimal[] { 5, 10, 20, 50, 100, 200, 500, 1000, 3000 };

            foreach (var step in stepArray)
            {
                Log.Info($"处理Step{step}数据");
                DateTime date = new DateTime(startDate.Year, 1, 1);

                while (date <= endDate)
                {
                    Log.Info($"处理{date.Year}年数据");

                    var records = context.YearTradeRecord.Where(x => x.Date == date && x.ChangeRate != null).AsNoTracking().ToList();

                    decimal lowLimit = -100;
                    decimal highLimit = lowLimit + step;

                    if (step > 100)
                    {
                        lowLimit = -step;
                        highLimit = 0;
                    }

                    while (lowLimit < maxChangeRate)
                    {
                        int count = records.Count(x => x.ChangeRate > lowLimit && x.ChangeRate <= highLimit);

                        var summary = new YearChangeRateSummary()
                        {
                            Date = date,
                            LowLimit = lowLimit,
                            HighLimit = highLimit,
                            Step = step,
                            Count = count
                        };

                        using (StockDbContext saveContext = new StockDbContext())
                        {
                            saveContext.YearChangeRateSummary.Add(summary);
                            saveContext.SaveChanges();
                        }

                        Log.Info($"{date}, {lowLimit}, {highLimit}, {count}");

                        lowLimit = highLimit;
                        highLimit += step;
                    }

                    date = date.AddYears(1);
                }
            }

            Log.Info("END");
        }
    }
}
