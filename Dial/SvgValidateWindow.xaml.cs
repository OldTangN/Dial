using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using Dial.Helper;
using Svg;
namespace Dial
{
    /// <summary>
    /// SvgValidateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SvgValidateWindow : Window
    {
        private string _FileName;
        public SvgGroup SvgGroup { get; private set; }
        public SvgValidateWindow(string fileName)
        {
            InitializeComponent();
            this._FileName = fileName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(_FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开Svg文件失败！\r\n" + ex.Message);
                return;
            }
            txtSvgContent.Text = xml.InnerXml;
        }

        private string GetBmpFromSvg(string svgDocContent, out BitmapImage bitmap)
        {
            bitmap = new BitmapImage();
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml(svgDocContent);
            }
            catch (Exception ex)
            {
                return "文件内容有错误！" + ex.Message;
            }

            SvgDocument doc;
            try
            {
                doc = SvgDocument.FromSvg<SvgDocument>(svgDocContent);
            }
            catch (Exception ex)
            {
                return "Svg文档内容格式错误！" + ex.Message;
            }
            if (doc == null)
            {
                return "Svg文档内容格式错误！";
            }
            System.Drawing.Bitmap bmp;
            try
            {
                bmp = doc.Draw();
            }
            catch (Exception ex)
            {
                return "Svg文档转成图片失败！" + ex.Message;
            }
            if (bmp == null)
            {
                return "Svg文档转成图片失败！";
            }
            try
            {
                bitmap = ImageHelper.GetImageSource(bmp);
            }
            catch (Exception ex)
            {
                return "图片转成ImageSource失败！" + ex.Message;
            }
            return "";
        }

        private void TxtSvgContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                BitmapImage bmpimg = new BitmapImage();
                string str = GetBmpFromSvg(txtSvgContent.Text, out bmpimg);
                if (!string.IsNullOrEmpty(str))
                {
                    return;
                }
                imgShowSvg.Source = bmpimg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            SvgDocument doc = SvgDocument.FromSvg<SvgDocument>(txtSvgContent.Text);
            if (doc == null)
            {
                MessageBox.Show("不是有效的Svg！");
                return;
            }
            var groups = doc.Children.FindSvgElementsOf<SvgGroup>();
            if (groups== null || groups.Count() == 0)
            {
                MessageBox.Show("找不到<g>标签！");
                return;
            }
            if (groups.Count() > 1)
            {
                MessageBox.Show("<g>标签数量不能多于1个!");
                return;
            }
            SvgGroup = groups.First();
            this.DialogResult = true;
        }
    }
}
