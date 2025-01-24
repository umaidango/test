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
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Timers;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Navigation;
using ICSharpCode.AvalonEdit.Search;
using Microsoft.Web.WebView2.Core;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fox_code_editor
{
    /// <summary>
    /// splash.xaml の相互作用ロジック
    /// </summary>
    public partial class splash : System.Windows.Window
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        public splash()
        {
            InitializeComponent();

            timer1.Start();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            
        }

        public void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Stop();
            this.Close();

            /*splash.Visibility = Visibility.Hidden;
            view1.Visibility = Visibility.Visible;
            */
        }
    }
}
