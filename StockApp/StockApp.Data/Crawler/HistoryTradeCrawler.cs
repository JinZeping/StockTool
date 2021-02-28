using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockApp.DB.Models;

namespace StockApp.Data.Crawler
{
    public class HistoryTradeCrawler : BaseCrawler
    {
        public Stock Stock { get; private set; }

        public void Open(Stock stock, int year, int season)
        {
            Stock = stock;
            string address = $"http://quotes.money.163.com/trade/lsjysj_{stock.Number}.html?year={year}&season={season}";
            Open(address);
        }

        public DayTradeRecord[] Get()
        {
            string[] args = new string[11];

            for (int i = 0; i < 11; i++)
            {
                args[i] = $"td[{i + 1}]";
            }

            var data = GetInnerTexts("/html/body/div[2]/div[4]/table/tbody/tr", args);

            if (data == null)
            {
                return null;
            }

            return data.Select(values =>
            {
                values = values.Select(x => x.Replace(",", "").Replace("--","-99999999.99")).ToArray();
                return new DayTradeRecord()
                {
                    StockID = Stock.ID,
                    Date = DateTime.Parse(values[0]),
                    Begin = decimal.Parse(values[1]),
                    Max = decimal.Parse(values[2]),
                    Min = decimal.Parse(values[3]),
                    End = decimal.Parse(values[4]),
                    Change = decimal.Parse(values[5]),
                    ChangeRate = decimal.Parse(values[6]),
                    TradeHand = decimal.Parse(values[7]),
                    TradeAmount = decimal.Parse(values[8]),
                    Amplitude = decimal.Parse(values[9]),
                    TurnoverRate = decimal.Parse(values[10])
                };
            }).ToArray();
        }
    }
}
