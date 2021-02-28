using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockApp.DB.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HtmlAgilityPack;

namespace StockApp.Data.Crawler
{
    public class FinancialSummaryCrawler : BaseCrawler
    {
        public Stock Stock { get; private set; }

        public void Open(Stock stock, TimeRange range)
        {
            Stock = stock;
            string rangeName = range switch
            {
                TimeRange.Year => "year",
                TimeRange.Season => "season",
                _ => throw new NotImplementedException()
            };

            string address = $"http://quotes.money.163.com/f10/zycwzb_{stock.Number},{rangeName}.html";
            Open(address);
        }

        public T[] Get<T>()
        {
            var node = GetNode("/html/body/div[2]/div[4]/div[1]/div[2]/div[8]/table/tbody/tr[1]");

            if (node == null)
            {
                return null;
            }

            int count = node.SelectNodes("th").Count;

            if (count == 0)
            {
                return null;
            }

            string[] args = new string[count];
            string[] args2 = new string[count];

            for (int i = 0; i < count; i++)
            {
                args[i] = $"td[{i + 1}]";
                args2[i] = $"th[{i + 1}]";
            }

            var data = GetInnerTexts("/html/body/div[2]/div[4]/div[1]/div[2]/div[8]/table/tbody/tr", args);
            var data2 = GetInnerTexts("/html/body/div[2]/div[4]/div[1]/div[2]/div[8]/table/tbody/tr[1]", args2)[0];
            data = data.Skip(1).ToList().Select(values => values.Select(x => x.Replace(",", "")).ToArray()).ToArray();
            if (data == null)
            {
                return null;
            }

            if (typeof(T) == typeof(SeasonFinancialSummary))
            {
                SeasonFinancialSummary[] summarys = new SeasonFinancialSummary[count];

                for (int i = 0; i < count; i++)
                {
                    decimal d;
                    SeasonFinancialSummary summary = new SeasonFinancialSummary()
                    {
                        StockID = Stock.ID
                    };

                    summary.Date = DateTime.Parse(data2[i]);
                    summary.PrimaryEarningsPerShare = decimal.TryParse(data[0][i], out d) ? d : null;
                    summary.NetAssetsPerShare = decimal.TryParse(data[1][i], out d) ? d : null;
                    summary.OperatingNetCashFlowPerShare = decimal.TryParse(data[2][i], out d) ? d : null;
                    summary.MainBusinessIncome = decimal.TryParse(data[3][i], out d) ? d : null;
                    summary.MainBusinessProfit = decimal.TryParse(data[4][i], out d) ? d : null;
                    summary.BusinessProfit = decimal.TryParse(data[5][i], out d) ? d : null;
                    summary.InvestmentReturn = decimal.TryParse(data[6][i], out d) ? d : null;
                    summary.NetNonOperatingIncome = decimal.TryParse(data[7][i], out d) ? d : null;
                    summary.TotalProfit = decimal.TryParse(data[8][i], out d) ? d : null;
                    summary.NetProfit = decimal.TryParse(data[9][i], out d) ? d : null;
                    summary.NetProfitAfterDeductingNonRecurring = decimal.TryParse(data[10][i], out d) ? d : null;
                    summary.NetCashFlowFromOperatingActivities = decimal.TryParse(data[11][i], out d) ? d : null;
                    summary.NetIncreaseInCashAndEquivalents = decimal.TryParse(data[12][i], out d) ? d : null;
                    summary.TotalAssets = decimal.TryParse(data[13][i], out d) ? d : null;
                    summary.CurrentAssets = decimal.TryParse(data[14][i], out d) ? d : null;
                    summary.TotalLiabilities = decimal.TryParse(data[15][i], out d) ? d : null;
                    summary.CurrentLiabilities = decimal.TryParse(data[16][i], out d) ? d : null;
                    summary.OwnerEquity = decimal.TryParse(data[17][i], out d) ? d : null;
                    summary.WeightedReturnOnEquity = decimal.TryParse(data[18][i], out d) ? d : null;

                    summarys[i] = summary;
                }

                return summarys as T[];
            }
            else if (typeof(T) == typeof(YearFinancialSummary))
            {
                YearFinancialSummary[] summarys = new YearFinancialSummary[count];

                for (int i = 0; i < count; i++)
                {
                    decimal d;
                    YearFinancialSummary summary = new YearFinancialSummary()
                    {
                        StockID = Stock.ID
                    };

                    summary.Date = DateTime.Parse(data2[i]);
                    summary.PrimaryEarningsPerShare = decimal.TryParse(data[0][i], out d) ? d : null;
                    summary.NetAssetsPerShare = decimal.TryParse(data[1][i], out d) ? d : null;
                    summary.OperatingNetCashFlowPerShare = decimal.TryParse(data[2][i], out d) ? d : null;
                    summary.MainBusinessIncome = decimal.TryParse(data[3][i], out d) ? d : null;
                    summary.MainBusinessProfit = decimal.TryParse(data[4][i], out d) ? d : null;
                    summary.BusinessProfit = decimal.TryParse(data[5][i], out d) ? d : null;
                    summary.InvestmentReturn = decimal.TryParse(data[6][i], out d) ? d : null;
                    summary.NetNonOperatingIncome = decimal.TryParse(data[7][i], out d) ? d : null;
                    summary.TotalProfit = decimal.TryParse(data[8][i], out d) ? d : null;
                    summary.NetProfit = decimal.TryParse(data[9][i], out d) ? d : null;
                    summary.NetProfitAfterDeductingNonRecurring = decimal.TryParse(data[10][i], out d) ? d : null;
                    summary.NetCashFlowFromOperatingActivities = decimal.TryParse(data[11][i], out d) ? d : null;
                    summary.NetIncreaseInCashAndEquivalents = decimal.TryParse(data[12][i], out d) ? d : null;
                    summary.TotalAssets = decimal.TryParse(data[13][i], out d) ? d : null;
                    summary.CurrentAssets = decimal.TryParse(data[14][i], out d) ? d : null;
                    summary.TotalLiabilities = decimal.TryParse(data[15][i], out d) ? d : null;
                    summary.CurrentLiabilities = decimal.TryParse(data[16][i], out d) ? d : null;
                    summary.OwnerEquity = decimal.TryParse(data[17][i], out d) ? d : null;
                    summary.WeightedReturnOnEquity = decimal.TryParse(data[18][i], out d) ? d : null;

                    summarys[i] = summary;
                }

                return summarys as T[];
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

    public enum TimeRange
    {
        Year,
        Season
    }
}
