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
using System.Windows.Forms;

namespace fox_code_editor
{
    /// <summary>
    /// devtool.xaml の相互作用ロジック
    /// </summary>
    public partial class devtool : Window
    {
        System.Windows.Forms.Timer splash_timer = new System.Windows.Forms.Timer();

        public devtool()
        {
            InitializeComponent();
            Topmost = true;
            splash_timer.Start();
            splash_timer.Interval = 1000;
            splash_timer.Tick += new EventHandler(splash_close);



        }

        public void splash_close(object sender, EventArgs e)
        {
            
            splash_timer.Stop();
            splash.Visibility = Visibility.Hidden;
            webview.Visibility = Visibility.Visible;
            rect.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
