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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Dial
{
    /// <summary>
    /// SchemeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SchemeWindow : MetroWindow
    {
        public SchemeWindow()
        {
            InitializeComponent();
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MiSchemeMgt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MiSysSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync("提示","测试消息框！");
        }
    }
}
