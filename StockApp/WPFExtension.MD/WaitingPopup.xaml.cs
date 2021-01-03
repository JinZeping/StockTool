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

namespace WPFExtension.MD
{
    /// <summary>
    /// WaitingPopup.xaml 的交互逻辑
    /// </summary>
    public partial class WaitingPopup : UserControl
    {
        public string Message { get; set; }
        public bool ShowCancelButton { get; set; }

        public WaitingPopup(string message = "请稍候", bool showCancelButton = false)
        {
            InitializeComponent();

            Message = message;
            ShowCancelButton = showCancelButton;
        }
    }
}
