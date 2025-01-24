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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ICSharpCode.AvalonEdit.Document.TextDocumentWeakEventManager;

namespace fox_code_editor
{
    /// <summary>
    /// setting.xaml の相互作用ロジック
    /// </summary>
    public partial class setting : System.Windows.Controls.UserControl
    {
        private bool dark;
        private bool chenge;


        public setting()
        {
            InitializeComponent();

            string this_color;
            string outputFilePath = "setting.udapp";
            string secondLine;
            string setting_data;
            string start_data_txt1;
            string start_data_txt2;
            chenge = false;

            try
            {
                using (StreamReader sr = new StreamReader(outputFilePath))
                {


                    setting_data = File.ReadAllText(outputFilePath);



                }



                start_data_txt1 = setting_data.Replace("Start date of use:", "");
                start_data_txt2 = start_data_txt1.Replace(".", "");
                Start_date.Text = "利用開始日：" + start_data_txt2;


            }

            catch (Exception ex)
            {
                Start_date.Text = "データの取得に失敗しました" + ex;
            }






            try
            {
                using (StreamReader sr = new StreamReader(outputFilePath))
                {


                    // 1行目を読み飛ばす
                    sr.ReadLine();

                    // 2行目を取得
                    secondLine = sr.ReadLine();



                }



                this_color = secondLine.Replace("color setting: ", "");
                theme_color.Text = "現在のテーマ：" + this_color;

                if (this_color == "black")
                {
                    dark = true;

                    color__set_btn.Content = "ライトモードに変更";

                }
                else
                {
                    dark = false;

                    color__set_btn.Content = "ダークモードに変更";
                }



            }

            catch (Exception ex)
            {

            }




        }



        private static readonly object fileLock = new object();

        private void display_color(object sender, RoutedEventArgs e)
        {
            chenge = true;
            lock (fileLock)
            {
                if (dark == true)
                {
                    dark = false;
                    theme_color.Text = "現在のテーマ：white";
                    color__set_btn.Content = "ダークモードに変更";

                    var lines = File.ReadAllLines("setting.udapp");
                    lines[1] = "color setting: white";
                    File.WriteAllLines("setting.udapp", lines);
                }
                else
                {
                    dark = true;
                    theme_color.Text = "現在のテーマ：black";
                    color__set_btn.Content = "ライトモードに変更";

                    var lines = File.ReadAllLines("setting.udapp");
                    lines[1] = "color setting: black";
                    File.WriteAllLines("setting.udapp", lines);
                }
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ratio_Click(object sender, RoutedEventArgs e)
        {
            lock (fileLock)
            {
                var lines = File.ReadAllLines("setting.udapp");
                lines[2] = "left_width: " + "1";
                File.WriteAllLines("setting.udapp", lines);
            }
        }

        private void reset(object sender, RoutedEventArgs e)
        {
            // メッセージボックスを表示
            DialogResult result = System.Windows.Forms.MessageBox.Show("初期化しますか？", "初期化", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                System.Windows.Forms.MessageBox.Show("初期化しました。\n アプリ再起動後に初期化が適用されます。", "完了", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            
        }
    }

}
