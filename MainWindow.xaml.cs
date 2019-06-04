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

namespace qrCodeExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void clickme_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.ShowDialog();
            BitmapImage bi = new BitmapImage(new Uri(ofd.FileName));
            //Image i = (Image)bi;

            int stride = bi.PixelWidth * 4;
            int size = bi.PixelHeight * stride;
            byte[] pixels = new byte[size];
            bi.CopyPixels(pixels, stride, 0);

           // int x = 299;
        //    int y = 299;

            for (int x = 0; x < bi.Width; x++)
            {
                for (int y = 0; y < bi.Height; y++)
                {
                    int index = y * stride + 4 * x;
                    byte blue = pixels[index];
                    byte green = pixels[index + 1];
                    byte red = pixels[index + 2];
                    byte alpha = pixels[index + 3];
                    if (red < 25 && green < 25 && blue < 25)
                    {
                        //   MessageBox.Show(red.ToString() + ", " + green.ToString() + ", " + blue.ToString());
                        MessageBox.Show("Black starts at: " + x.ToString() + ", " + y.ToString());
                    }

                }
            }
            MessageBox.Show(bi.Width.ToString() + ", " + bi.Height.ToString());

        }
    }
}
