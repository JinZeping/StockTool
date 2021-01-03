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
    /// TipPopup.xaml 的交互逻辑
    /// </summary>
    public partial class TipPopup : UserControl
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public TipPopup(string message, string title = "提示")
        {
            InitializeComponent();

            Message = message;
            Title = title;
        }
    }
}
