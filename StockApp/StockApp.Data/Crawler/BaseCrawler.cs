using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HtmlAgilityPack;

namespace StockApp.Data.Crawler
{
    public class BaseCrawler : IDisposable
    {
        public ChromeDriver Driver { get; private set; }

        public BaseCrawler()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            //options.AddArgument("--nogpu");
            options.AddArguments("--test-type", "--ignore-certificate-errors");
            options.AddArgument("enable-automation");
            Driver = new ChromeDriver(options);
            Log.Debug("ChromeDriver inited");
        }

        ~BaseCrawler()
        {
            if (Driver != null)
            {
                Driver.Dispose();
            }
        }

        public virtual void Open(string address, params string[] args)
        {
            address = string.Format(address, args);
            int retryCount = 3;
            
            while(retryCount-- > 0)
            {
                try
                {
                    Driver.Navigate().GoToUrl(address);
                    Log.Debug($"ChromeDriver open address {address}");
                    break;
                }
                catch (WebDriverException)
                {
                    continue;
                }
            }
        }

        public virtual HtmlNode GetNode(string xpath)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(Driver.PageSource);
            return htmlDoc.DocumentNode.SelectSingleNode(xpath);
        }

        public virtual string[][] GetInnerTexts(string baseXPath, params string[] args)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(Driver.PageSource);
            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes(baseXPath);

            if (nodes == null)
            {
                return null;
            }

            string[][] result = new string[nodes.Count][];

            for (int i = 0; i < nodes.Count; i++)
            {
                string[] values = new string[args.Length];
                var node = nodes[i];

                for(int j = 0; j < args.Length; j++)
                {
                    values[j] = node.SelectSingleNode(args[j])?.InnerText;
                }

                result[i] = values;
            }

            return result;
        }

        public void Dispose()
        {
            if (Driver != null)
            {
                Driver.Dispose();
            }
        }
    }
}
