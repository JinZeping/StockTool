using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockApp.DB.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HtmlAgilityPack;

namespace StockApp.Crawler
{
    public class FinancialBriefCrawler : BaseCrawler
    {
        public Stock Stock { get; private set; }

        public void Open(Stock stock, TimeRange range)
        {
            Stock = stock;
            string rangeName = range switch
            {
                TimeRange.Year => "?type=year",
                TimeRange.Season => "",
                _ => throw new NotImplementedException()
            };

            string address = $"http://quotes.money.163.com/f10/cwbbzy_{stock.Number}.html{rangeName}";
            Open(address);
        }

        public T[] Get<T>()
        {
            var node = GetNode("/html/body/div[2]/div[4]/div/div[4]/table/tbody/tr[1]");

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

            var data = GetInnerTexts("/html/body/div[2]/div[4]/div/div[4]/table/tbody/tr", args);
            var data2 = GetInnerTexts("/html/body/div[2]/div[4]/div/div[4]/table/tbody/tr[1]", args2)[0];
            data = data.Skip(1).ToList().Select(values => values.Select(x => x?.Replace(",", "")).ToArray()).ToArray();

            if (data == null)
            {
                return null;
            }

            if (typeof(T) == typeof(SeasonFinancialBrief))
            {
                SeasonFinancialBrief[] summarys = new SeasonFinancialBrief[count];

                for (int i = 0; i < count; i++)
                {
                    decimal d;
                    SeasonFinancialBrief summary = new SeasonFinancialBrief()
                    {
                        StockID = Stock.ID
                    };

                    summary.Date = DateTime.Parse(data2[i]);
                    summary.OperatingIncome = decimal.TryParse(data[1][i], out d) ? d : null;
                    summary.OperatingCosts = decimal.TryParse(data[2][i], out d) ? d : null;
                    summary.OperatingProfit = decimal.TryParse(data[3][i], out d) ? d : null;
                    summary.TotalProfit = decimal.TryParse(data[4][i], out d) ? d : null;
                    summary.IncomeTax = decimal.TryParse(data[5][i], out d) ? d : null;
                    summary.NetProfit = decimal.TryParse(data[6][i], out d) ? d : null;
                    summary.BasicEarningPerShare = decimal.TryParse(data[7][i], out d) ? d : null;
                    summary.Money = decimal.TryParse(data[9][i], out d) ? d : null;
                    summary.Receivables = decimal.TryParse(data[10][i], out d) ? d : null;
                    summary.Inventory = decimal.TryParse(data[11][i], out d) ? d : null;
                    summary.TotalCurrentAssets = decimal.TryParse(data[12][i], out d) ? d : null;
                    summary.NetFixedAssets = decimal.TryParse(data[13][i], out d) ? d : null;
                    summary.TotalAssets = decimal.TryParse(data[14][i], out d) ? d : null;
                    summary.TotalCurrentLiabilities = decimal.TryParse(data[15][i], out d) ? d : null;
                    summary.TotalNonCurrentLiabilities = decimal.TryParse(data[16][i], out d) ? d : null;
                    summary.TotalLiabilities = decimal.TryParse(data[17][i], out d) ? d : null;
                    summary.TotalOwnerEquity = decimal.TryParse(data[18][i], out d) ? d : null;
                    summary.BeginBalanceOfCashAndCashEquivalents = decimal.TryParse(data[20][i], out d) ? d : null;
                    summary.NetCashFlowFromOperating = decimal.TryParse(data[21][i], out d) ? d : null;
                    summary.NetCashFlowFromInvestment = decimal.TryParse(data[22][i], out d) ? d : null;
                    summary.NetCashFlowFromFinancing = decimal.TryParse(data[23][i], out d) ? d : null;
                    summary.NetIncreaseInCashAndCashEquivalents = decimal.TryParse(data[24][i], out d) ? d : null;
                    summary.EndBalanceOfCashAndCashEquivalents = decimal.TryParse(data[25][i], out d) ? d : null;

                    summarys[i] = summary;
                }

                return summarys as T[];
            }
            else if (typeof(T) == typeof(YearFinancialBrief))
            {
                YearFinancialBrief[] summarys = new YearFinancialBrief[count];

                for (int i = 0; i < count; i++)
                {
                    decimal d;
                    YearFinancialBrief summary = new YearFinancialBrief()
                    {
                        StockID = Stock.ID
                    };

                    summary.Date = DateTime.Parse(data2[i]);
                    summary.OperatingIncome = decimal.TryParse(data[1][i], out d) ? d : null;
                    summary.OperatingCosts = decimal.TryParse(data[2][i], out d) ? d : null;
                    summary.OperatingProfit = decimal.TryParse(data[3][i], out d) ? d : null;
                    summary.TotalProfit = decimal.TryParse(data[4][i], out d) ? d : null;
                    summary.IncomeTax = decimal.TryParse(data[5][i], out d) ? d : null;
                    summary.NetProfit = decimal.TryParse(data[6][i], out d) ? d : null;
                    summary.BasicEarningPerShare = decimal.TryParse(data[7][i], out d) ? d : null;
                    summary.Money = decimal.TryParse(data[9][i], out d) ? d : null;
                    summary.Receivables = decimal.TryParse(data[10][i], out d) ? d : null;
                    summary.Inventory = decimal.TryParse(data[11][i], out d) ? d : null;
                    summary.TotalCurrentAssets = decimal.TryParse(data[12][i], out d) ? d : null;
                    summary.NetFixedAssets = decimal.TryParse(data[13][i], out d) ? d : null;
                    summary.TotalAssets = decimal.TryParse(data[14][i], out d) ? d : null;
                    summary.TotalCurrentLiabilities = decimal.TryParse(data[15][i], out d) ? d : null;
                    summary.TotalNonCurrentLiabilities = decimal.TryParse(data[16][i], out d) ? d : null;
                    summary.TotalLiabilities = decimal.TryParse(data[17][i], out d) ? d : null;
                    summary.TotalOwnerEquity = decimal.TryParse(data[18][i], out d) ? d : null;
                    summary.BeginBalanceOfCashAndCashEquivalents = decimal.TryParse(data[20][i], out d) ? d : null;
                    summary.NetCashFlowFromOperating = decimal.TryParse(data[21][i], out d) ? d : null;
                    summary.NetCashFlowFromInvestment = decimal.TryParse(data[22][i], out d) ? d : null;
                    summary.NetCashFlowFromFinancing = decimal.TryParse(data[23][i], out d) ? d : null;
                    summary.NetIncreaseInCashAndCashEquivalents = decimal.TryParse(data[24][i], out d) ? d : null;
                    summary.EndBalanceOfCashAndCashEquivalents = decimal.TryParse(data[25][i], out d) ? d : null;

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
}
