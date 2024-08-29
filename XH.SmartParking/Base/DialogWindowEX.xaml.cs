using Prism.Services.Dialogs;
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
using System.Windows.Shapes;

namespace XH.SmartParking.Base
{
    /// <summary>
    /// DialogWindowEX.xaml 的交互逻辑
    /// </summary>
    public partial class DialogWindowEX : Window, IDialogWindow
    {
        public DialogWindowEX()
        {
            InitializeComponent();

            //this.Loaded += DialogWindowEX_Loaded;
            //// 窗口数据加载完之后执行
            //this.ContentRendered += DialogWindowEX_ContentRendered;
        }

        private void DialogWindowEX_Loaded(object sender, RoutedEventArgs e)
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void DialogWindowEX_ContentRendered(object? sender, EventArgs e)
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        public IDialogResult Result { get ; set ; }
    }
}
