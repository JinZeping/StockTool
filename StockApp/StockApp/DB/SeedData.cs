using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockApp.DB.Models;
using System.IO;

namespace StockApp.DB
{
    public class SeedData
    {
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

                while(true)
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

            foreach(var stockID in stockIDList)
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
    }
}
