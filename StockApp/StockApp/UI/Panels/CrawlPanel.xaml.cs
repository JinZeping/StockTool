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
using System.ComponentModel;

namespace StockApp.UI.Panels
{
    /// <summary>
    /// CrawlPanel.xaml 的交互逻辑
    /// </summary>
    public partial class CrawlPanel : UserControl
    {
        public BindingList<string> MessageList { get; private set; } = new BindingList<string>();

        public CrawlPanel()
        {
            InitializeComponent();

            viewModel.ClearMessageEventHandler += ViewModel_ClearMessageEventHandler;
            viewModel.AddMessageEventHandler += ViewModel_AddMessageEventHandler;
        }

        private void ViewModel_ClearMessageEventHandler()
        {
            Dispatcher.Invoke(() => MessageList.Clear());
        }

        private void ViewModel_AddMessageEventHandler(string msg)
        {
            Dispatcher.Invoke(() => MessageList.Add(msg));
        }
    }
}
