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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace fox_code_editor
{
    /// <summary>
    /// setup_window.xaml の相互作用ロジック
    /// </summary>
    public partial class setup_window : Window
    {
        public setup_window()
        {
            InitializeComponent();

            // テキストファイルのパス
            string outputFilePath = "setting.udapp";

            // ファイルに書き込む
            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                string time = DateTime.Now.ToString();
                sw.WriteLine("Start date of use:" + time + "." + "\ncolor setting: white" + "\n");
            }

            /*
            page1();
            page2();
            page3();
            */

        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

     
        }
    }
