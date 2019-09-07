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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MiSchemeMgt_Click(object sender, RoutedEventArgs e)
        {
            SchemeWindow win = new SchemeWindow();
            win.Owner = this;
            win.ShowDialog();
        }

        private void MiSysSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MiHelp_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync("提示", "TODO:显示PDF用户手册");
        }
    }
}
