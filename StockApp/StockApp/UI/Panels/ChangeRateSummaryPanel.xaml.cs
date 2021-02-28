using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using StockApp.DB;
using Microsoft.EntityFrameworkCore;

namespace StockApp.UI.Panels
{
    /// <summary>
    /// ChangeRateSummaryPanel.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeRateSummaryPanel : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; } = new SeriesCollection();
        public Func<double, string> XFormatter { get; set; } = val => new DateTime((long)val).ToString("yyyy");
        public Func<double, string> YFormatter { get; set; } = val => val.ToString("N");

        public ChangeRateSummaryPanel()
        {
            InitializeComponent();

            cboStep.ItemsSource = new List<SummaryChartSetting>()
            {
                new SummaryChartSetting()
                {
                    Name = "Setting1",
                    Steps = new List<decimal>() {100, 3000 }
                },
                new SummaryChartSetting()
                {
                    Name = "Setting2",
                    Steps = new List<decimal>() { 50, 50, 50, 50, 100, 200, 200 }
                },
                new SummaryChartSetting()
                {
                    Name = "Setting3",
                    Steps = new List<decimal>() { 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 100, 100, 100, 100, 500, 1000, 1000}
                }
            };

            DataContext = this;


        }

        private void cboStep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SeriesCollection.Clear();
            SummaryChartSetting setting = cboStep.SelectedItem as SummaryChartSetting;
            StackMode mode = (StackMode)cboStackMode.SelectedItem;

            if (setting == null)
            {
                return;
            }

            StockDbContext context = new StockDbContext();
            decimal lowLimit = -100;

            foreach (var step in setting.Steps)
            {
                byte r, g, b;
                decimal mid = lowLimit + step / 2;

                if (mid <= -60)
                {
                    r = 0;
                    g = (byte)(255 - (-mid - 60) / 40 * 128);
                    b = 0;
                }
                else if (mid > -60 && mid < 0)
                {
                    r = (byte)((mid + 60) / 60 * 255);
                    g = 255;
                    b = (byte)((mid + 60) / 60 * 255);
                }
                else if (mid >= 0 && mid <= 200)
                {
                    r = 255;
                    g = (byte)((-mid + 200) / 200 * 255);
                    b = (byte)((-mid + 200) / 200 * 255);
                }
                else
                {
                    r = (byte)(256 - (mid - 200) / 3000 * 128);
                    g = 0;
                    b = 0;
                }

                SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(r, g, b));

                SeriesCollection.Add(new StackedAreaSeries()
                {
                    Title = $"{lowLimit}~{lowLimit + step}",
                    Fill = brush,
                    LineSmoothness = 0.5,
                    StackMode = mode,
                    Values = new ChartValues<DateTimePoint>(
                        context.YearChangeRateSummary.Where(x => x.LowLimit == lowLimit && x.Step == step)
                        .OrderBy(x => x.Date).AsNoTracking().ToList().Select(x => new DateTimePoint(x.Date, x.Count)))
                });

                lowLimit += step;
            }
        }

        private void cboStackMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackMode mode = (StackMode)cboStackMode.SelectedItem;

            foreach (var series in SeriesCollection)
            {
                (series as StackedAreaSeries).StackMode = mode;
            }
        }
    }

    class SummaryChartSetting
    {
        public string Name { get; set; }

        public List<decimal> Steps { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
