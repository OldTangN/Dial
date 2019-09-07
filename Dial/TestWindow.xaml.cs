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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using Svg;
using Svg.Pathing;
using Svg.Transforms;

namespace Dial
{
    /// <summary>
    /// TestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TestWindow : MetroWindow
    {
        public TestWindow()
        {
            InitializeComponent();
        }

        private void BtnGen_Click(object sender, RoutedEventArgs e)
        {
            gdView.Children.Clear();

            double long_len = Convert.ToDouble(txtLongLen.Text),
                short_width = Convert.ToDouble(txtShortLen.Text),
                long_height = Convert.ToDouble(txtLongWidth.Text),
                short_height = Convert.ToDouble(txtShortWidth.Text),
                padding = Convert.ToDouble(txtRadius.Text) - long_len / 2;
            for (int i = 0; i < 360; i += 10)
            {
                if (i % 30 == 0)
                {
                    var rect = GetLine(long_len, long_height, i, padding, true);
                    gdView.Children.Add(rect);
                }
                else
                {
                    var rect = GetLine(short_width, short_height, i, padding + long_len / 2 - short_width / 2, false);
                    gdView.Children.Add(rect);
                }
            }
            GenFix();
        }

        private void GenFix()
        {
            Ellipse circle = new Ellipse();
            circle.Width = circle.Height = 10;
            circle.Fill = new SolidColorBrush(Colors.Black);
            TextBlock txtFac = new TextBlock();
            txtFac.Text = "华清仪表";
            txtFac.FontSize = 20;
            txtFac.FontFamily = new FontFamily("微软雅黑");
            txtFac.HorizontalAlignment = HorizontalAlignment.Center;
            txtFac.VerticalAlignment = VerticalAlignment.Center;
            txtFac.Margin = new Thickness(0, 150, 0, 0);
            gdView.Children.Add(circle);
            gdView.Children.Add(txtFac);
        }

        private Rectangle GetLine(double width, double height, double angle, double padding, bool islong)
        {
            Rectangle rect = new Rectangle();
            rect.HorizontalAlignment = HorizontalAlignment.Center;
            rect.VerticalAlignment = VerticalAlignment.Center;
            rect.Width = width;
            rect.Height = height;
            rect.Fill = new SolidColorBrush(islong ? Colors.Blue : Colors.Black);
            TransformGroup group = new TransformGroup();
            TranslateTransform translate = new TranslateTransform(padding, height / 2);
            RotateTransform rotate = new RotateTransform(angle, width / 2, height / 2);
            group.Children.Add(translate);
            group.Children.Add(rotate);
            rect.RenderTransform = group;
            return rect;
        }

        private void BtnExportImg_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "*.jpg|*.jpg";
            if (!fileDialog.ShowDialog().GetValueOrDefault())
            {
                return;
            }
            double dpi = Convert.ToDouble(txtDpi.Text);
            double scale = dpi / 96;
            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)(scale * gdView.ActualWidth), (int)(scale * gdView.ActualHeight), dpi, dpi, PixelFormats.Default);

            // Save current transform
            Transform transform = gdView.LayoutTransform;
            gdView.LayoutTransform = null;

            //gdView.Arrange(new Rect(0, 0, gdView.ActualWidth, gdView.ActualHeight));
            bitmap.Render(gdView);
            JpegBitmapEncoder encode = new JpegBitmapEncoder();
            encode.Frames.Add(BitmapFrame.Create(bitmap));
            FileStream fs = new FileStream(fileDialog.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            encode.Save(fs);
            fs.Close();
            fs.Dispose();
            gdView.LayoutTransform = transform;
        }

        private void BtnSVG_Click(object sender, RoutedEventArgs e)
        {
            var blue = new SvgColourServer(System.Drawing.Color.Blue);
            var yellow = new SvgColourServer(System.Drawing.Color.Yellow);
            var white = new SvgColourServer(System.Drawing.Color.White);
            var black = new SvgColourServer(System.Drawing.Color.Black);
            SvgDocument svgdoc = new SvgDocument();
            svgdoc.Width = new SvgUnit(SvgUnitType.Pixel, 500);
            svgdoc.Height = new SvgUnit(SvgUnitType.Pixel, 500);
            svgdoc.ViewBox = new SvgViewBox(0, 0, 500, 500);

            var group = new SvgGroup();
            svgdoc.Children.Add(group);
            var dd = new SvgFontStyleConverter();
            group.Children.Add(new SvgText
            {
                Text = "华青仪表",
                X = new SvgUnitCollection { new SvgUnit(SvgUnitType.Pixel, 100) },
                Y = new SvgUnitCollection { new SvgUnit(SvgUnitType.Pixel, 100) },
                FontSize = new SvgUnit(SvgUnitType.Point, 20),
                Fill = black,
                Font = "黑体"
            });

            SvgLine line = new SvgLine();
            line.StartX = new SvgUnit(SvgUnitType.Pixel, 10);
            line.StartY = new SvgUnit(SvgUnitType.Pixel, 110);
            line.EndX = new SvgUnit(SvgUnitType.Pixel, 400);
            line.EndY = new SvgUnit(SvgUnitType.Pixel, 400);
            SvgCircle circle = new SvgCircle()
            {
                CenterX = 250,
                CenterY = 250,
                Stroke = blue,
                Radius = 50,
                StrokeWidth = new SvgUnit(SvgUnitType.Pixel, 5)
            };
            group.Children.Add(circle);
            line.Stroke = blue;
            line.Fill = blue;
            line.StrokeWidth = new SvgUnit(SvgUnitType.Pixel, 5);
            group.Children.Add(line);

            #region 使用时，svg文档与数据库
            /*注：XmlDocument读取svg文档内容，保存数据库（），
            然后SvgDocument.FromSvg<SvgDocument>()读取SvgDocument，在提取里面的<g>标签，
            给<g>加上平移变换translate即可实现将现有svg文档导入另外一个文档*/
            //string strDoc = "";
            //XmlDocument xmldoc = new XmlDocument();
            //xmlDoc.Load(openSvgFile.FileName);
            //strDoc = xmlDoc.InnerXml;
            //SaveDB(strDoc);
            //strDoc = ReadFromDB();
            //xmldoc.LoadXml(strDoc);
            //var dd = SvgDocument.FromSvg<SvgDocument>(strDoc);
            //var g = dd.Children.FindSvgElementOf<SvgGroup>();
            #endregion

            //加载表盘测试.svg，将其中的group 加入到当前svg
            SvgDocument svgtest = SvgDocument.Open("表盘测试.svg");
            var groupstest = svgtest.Children.FindSvgElementsOf<SvgGroup>();
            foreach (var g in groupstest)
            {
                g.Transforms.Add(new Svg.Transforms.SvgTranslate(50, 50));
                group.Children.Add(g);
            }

            //string strPath = @"<path transform=""translate(-20,0)"" fill-rule=""evenodd"" clip-rule=""evenodd"" fill=""none"" stroke=""#000000"" stroke-width=""1.4173"" stroke-miterlimit=""2.4142"" d=""
            //M217.274,209.852c4.294,0,7.796,3.502,7.796,7.795c0,4.295-3.502,7.797-7.796,7.797s-7.795-3.502-7.795-7.797
            //C209.479,213.354,212.98,209.852,217.274,209.852L217.274,209.852z""/>";
            /*
             <path transform="translate(-20,0)" fill-rule="evenodd" clip-rule="evenodd" fill="none" stroke="#000000" stroke-width="1.4173" stroke-miterlimit="2.4142" d="
				M217.274,209.852c4.294,0,7.796,3.502,7.796,7.795c0,4.295-3.502,7.797-7.796,7.797s-7.795-3.502-7.795-7.797
				C209.479,213.354,212.98,209.852,217.274,209.852L217.274,209.852z"/>
             */
            //var b = SvgPathBuilder.Parse(@"M217.274,209.852c4.294,0,7.796,3.502,7.796,7.795c0,4.295-3.502,7.797-7.796,7.797s-7.795-3.502-7.795-7.797
            //    C209.479, 213.354, 212.98, 209.852, 217.274, 209.852L217.274, 209.852z");
            //SvgPath p = new SvgPath();
            //p.PathData = b;
            //group.Children.Add(p);

            svgdoc.Write("456.svg");
            svgdoc.Draw().Save("456.png", System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("456.svg + 456.png");
            BitmapImage bitmap = GetBitmap("456.png");
            img.Source = bitmap;
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            var red = new SvgColourServer(System.Drawing.Color.Red);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "svg文件|*.svg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                string path = openFileDialog.FileName;
                SvgDocument svgdoc = SvgDocument.Open(path);
                var lines = svgdoc.Children.FindSvgElementsOf<SvgLine>();
                foreach (var item in lines)
                {
                    item.Stroke = red;
                }
                svgdoc.Draw().Save("tmp.png", System.Drawing.Imaging.ImageFormat.Png);
                BitmapImage bitmap = GetBitmap("tmp.png");
                img.Source = bitmap;
            }
        }

        private static BitmapImage GetBitmap(string filename)
        {
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(filename));
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = ms;
            bitmap.EndInit();
            bitmap.Freeze();
            ms.Close();
            ms.Dispose();
            return bitmap;
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            SvgValidateWindow win = new SvgValidateWindow("表盘测试.svg");
            bool? rlt = win.ShowDialog();
            if (!rlt.GetValueOrDefault())
            {
                return;
            }
            SvgGroup group2Import = win.SvgGroup;
            group2Import.Transforms.Add(new SvgTranslate(20, 20));

            return;
            var doc = SvgDocument.Open("表盘测试.svg");
            var bmp = doc.Draw();
            //MessageBox.Show(bmp.PixelFormat.ToString());
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = ms;
            bitmap.EndInit();
            bitmap.Freeze();
            ms.Close();
            ms.Dispose();
            img.Source = bitmap;
            //string strDoc = "<......>";
            //XmlDocument xmldoc = new XmlDocument();
            //xmldoc.Load("表盘测试.svg");
            //xmldoc.LoadXml(strDoc);
            //var dd = SvgDocument.FromSvg<SvgDocument>(strDoc);
            //var pp = dd.Children.FindSvgElementOf<SvgPath>();                   
        }
    }
}
