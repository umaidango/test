using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControlzEx.Standard;
using Forge.OpenAI.Models.Messages;
using ICSharpCode.AvalonEdit.Search;
using Microsoft.Web.WebView2.Core;
using Microsoft.Win32;
using Microsoft.Windows.Themes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Path = System.IO.Path;
using ICSharpCode.AvalonEdit.Document;
using MessageBox = System.Windows.Forms.MessageBox;

namespace fox_code_editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private Storyboard _loaderAnimation;

        string outputFilePath = "setting.udapp";

        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        //マウスのクリック位置を記憶
        private Point mousePoint;

        public MainWindow()
        {


            InitializeComponent();//初期化

            splash_event();
            startup_event_1();
            theme__s();
            teigi();

            
        }



        // アニメーションを開始するメソッド
        private void StartAnimation()
        {
            _loaderAnimation.Begin();
        }

        // アニメーションを停止するメソッド
        private void StopAnimation()
        {
            _loaderAnimation.Stop();
        }


        public void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Stop();

            /*splash.Visibility = Visibility.Hidden;
            view1.Visibility = Visibility.Visible;
            */
        }

        private void main_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e is MouseButtonEventArgs mouseEventArgs)
            {
                if (mouseEventArgs.LeftButton == MouseButtonState.Pressed)
                {
                    // コントロール内の相対座標を取得
                    mousePoint = new Point(e.GetPosition(sender as UIElement).X, e.GetPosition(sender as UIElement).Y);

                }
            }
        }

        private void main_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // ウィンドウの位置を移動
                double deltaX = e.GetPosition(this).X - mousePoint.X;
                double deltaY = e.GetPosition(this).Y - mousePoint.Y;

                // Canvas上に配置している場合
                // Canvas.SetLeft(this, Canvas.GetLeft(this) + deltaX);
                // Canvas.SetTop(this, Canvas.GetTop(this) + deltaY);

                // 直接ウィンドウの位置を変更する場合
                this.Left += deltaX;
                this.Top += deltaY;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }



        private void close_button_MouseUp_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void open_file_click(object sender, RoutedEventArgs e)
        {


            //[1]OpenFileDialogのオブジェクトを作成します。
            var ofd = new Microsoft.Win32.OpenFileDialog();

            //[3]ダイアログの処理です。

            if (ofd.ShowDialog() == true)
            {
                view1.Source = new Uri(ofd.FileName, UriKind.Absolute);
                directory.Text = ofd.FileName;

                if (File.Exists(ofd.FileName))
                {
                    //第1引数に読み込むファイルパス 第2引数に文字コードを指定
                    StreamReader strd = new StreamReader(ofd.FileName, Encoding.GetEncoding("UTF-8"));

                    // 読み込み
                    textEditor.Text = strd.ReadToEnd();

                    // close
                    strd.Close();



                }

            }
        }

        private void save_in(object sender, RoutedEventArgs e)
        {

            string fileName = directory.Text;
            string text = textEditor.Text;

            // UTF-8でファイルに書き込む
            File.WriteAllText(fileName, text, Encoding.UTF8);

            view1.Reload();

        }

        private void textEditor_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {



        }


        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            if (!e.IsRepeat
                & Keyboard.GetKeyStates(Key.LeftCtrl).HasFlag(KeyStates.Down)
                & Keyboard.GetKeyStates(Key.S).HasFlag(KeyStates.Down))
            {
                string fileName = directory.Text;
                string text = textEditor.Text;

                // UTF-8でファイルに書き込む
                File.WriteAllText(fileName, text, Encoding.UTF8);

                view1.Reload();
            }


        }



        private void version_dialog(object sender, RoutedEventArgs e)
        {
            ver ver = new ver();
            ver.ShowDialog();
        }

        private void credit_dialog(object sender, RoutedEventArgs e)
        {
            credit credit = new credit();
            credit.ShowDialog();
        }

        private void link_webview_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (!e.IsRepeat & Keyboard.GetKeyStates(Key.Enter).HasFlag(KeyStates.Down))
            {

                view1.Source = new Uri(link_webview.Text, UriKind.Absolute);



            }

        }

        private void webView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {

            title.Text = (view1.CoreWebView2.DocumentTitle);
            //load_icon.Visibility = Visibility.Hidden;

            link_webview.Text = view1.Source.ToString();
            // Storyboardのインスタンスを取得

            Canvas.SetLeft(loader, 0);
            loader.Visibility = Visibility.Hidden;
            StopAnimation();

            pkg_d_check();
        }



        private void link_webview_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void save_2(object sender, RoutedEventArgs e)
        {
            // ファイル選択ダイアログを表示
            System.Windows.Forms.SaveFileDialog? saveFileDialog = new System.Windows.Forms.SaveFileDialog();




            if (saveFileDialog.ShowDialog() != null)
            {
                string fileName = saveFileDialog.FileName;
                string text = textEditor.Text;

                // UTF-8でファイルに書き込む
                File.WriteAllText(fileName, text, Encoding.UTF8);


            }
            else
            {
                // strがnullの場合の処理
            }

        }

        private void max_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }

            else
            {
                WindowState = WindowState.Maximized;
            }

        }

        private void view1_ContentLoading(object sender, CoreWebView2ContentLoadingEventArgs e)
        {
            Canvas.SetLeft(loader, 0);
            loader.Visibility = Visibility.Visible;
            StartAnimation();

        }

        private void view1_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void close_window_MouseDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Close();
        }

        private void mini_max_window_MouseDown(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void back_view_site(object sender, RoutedEventArgs e)
        {
            view1.GoBack();
        }

        private void next_view_site(object sender, RoutedEventArgs e)
        {
            view1.GoForward();
        }

        private void reload_site(object sender, RoutedEventArgs e)
        {
            view1.Reload();
        }

        private void hidden_window(object sender, System.Windows.Input.MouseEventArgs args)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void mini_max_window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void windown_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }


        private void window_main_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            splitter_s.Height = this.Height;



        }

        private void view1_Initialized(object sender, EventArgs e)
        {
        }

        private void code_s_click(object sender, RoutedEventArgs e)
        {
            devtool devtool = new devtool();
            devtool.Show();
        }

        private void setting(object sender, RoutedEventArgs e)
        {

        }

        private void close_startup_dialog(object sender, RoutedEventArgs e)
        {

        }

        private void new_win_s(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();

        }

        private void setting_open(object sender, RoutedEventArgs e)
        {
            setting_menu.Visibility = Visibility.Visible;
            view1.Visibility = Visibility.Collapsed;
            setting_menu_close.Visibility = Visibility.Visible;
        }

        

        private void display_color(object sender, RoutedEventArgs e)
        {
            if (((SolidColorBrush)this.Background).Color == Color.FromArgb(255, 255, 255, 255))
            {
                this.Background = new SolidColorBrush(Color.FromArgb(255, 85, 85, 85));
            }
            else if (((SolidColorBrush)this.Background).Color == Color.FromArgb(255, 85, 85, 85))
            {
                this.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }


        string this_color;
        string secondLine;
        string thirdLine;
        private bool dark;



        private void theme__s()
        {


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

                if (this_color == "black")
                {
                    dark = true;
                    window_main.Background = new SolidColorBrush(Color.FromArgb(255, 55, 55, 55));
                    file.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    help.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

                }
                else
                {
                    dark = false;
                    window_main.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));


                }



            }

            catch (Exception ex)
            {

            }

        }


        private void splash_event()
        {
            splash splash = new splash();
            splash.ShowDialog();
            timer1.Start();
            timer1.Interval = 550;

        }


        private void startup_event_1()
        {
            string setting;
            try
            {
                using (StreamReader sr = new StreamReader(outputFilePath))
                {
                    setting = sr.ReadLine();
                }
            }

            catch (Exception ex)
            {
                setup_window setup_Window = new setup_window();
                setup_Window.ShowDialog();
            }

            o_folder_btn.Opacity = 0.5;

        }

        private void GridSplitter_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void GridSplitter_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            double left_width = LeftColumn.Width.Value;
            double right_width = RightColumn.Width.Value;
        }

        
        private void Setting_menu_close(object sender, RoutedEventArgs e)
        {
            setting_menu.Visibility = Visibility.Hidden;
            view1.Visibility = Visibility.Visible;
            setting_menu_close.Visibility = Visibility.Hidden;
            theme__s();
            
        }

        private void package_btn_Click(object sender, RoutedEventArgs e)
        {
            pkg_menu.Visibility = Visibility.Visible;
            view1.Visibility = Visibility.Collapsed;
        }

        private void pkg_menu_close_Click(object sender, RoutedEventArgs e)
        {
            pkg_menu.Visibility = Visibility.Hidden;
            view1.Visibility = Visibility.Visible;

        }

        string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "package_unzip01", "fce_prj1");

        private void pkg_d_check()
        {
            string fileName = "pkg_data.udapp";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            string fileContents;


            if (File.Exists(filePath))
            {

                using (StreamReader sr = new StreamReader(filePath))
                {
                    fileContents = sr.ReadLine();
                }

                fileContents = File.ReadAllText(filePath, Encoding.UTF8);

                if (fileContents == "<this_pack> [open]package1")
                {
                    o_folder_btn.Visibility = Visibility.Visible;
                    project_name.Visibility = Visibility.Visible;
                    string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "package_unzip01", "fce_prj1");
                    string fileName__ = "index.html";
                    string filePath__ = Path.Combine(directoryPath, fileName__);
                    string trim_f = fileContents.Replace("<this_pack> ", "");
                    string trim_ff = trim_f.Replace("[open]", "");
                    o_folder_btn.Opacity = 1;

                    if (File.Exists(filePath__))
                    {
                        directory.Text = filePath__;
                        view1.Source = new Uri(filePath__, UriKind.Absolute);
                        link_webview.Text = filePath__;

                        project_name.Text = trim_ff;
                        o_folder_btn.Visibility = Visibility.Visible;
                        //第1引数に読み込むファイルパス 第2引数に文字コードを指定
                        StreamReader strd = new StreamReader(filePath__, Encoding.GetEncoding("UTF-8"));

                        // 読み込み
                        textEditor.Text = strd.ReadToEnd();

                        // close
                        strd.Close();



                    }



                }



                if (fileContents == "<this_pack> package1")
                {
                    string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "package_unzip01", "fce_prj1");
                    string fileName__ = "index.html";
                    string filePath__ = Path.Combine(directoryPath, fileName__);
                    string trim_f = fileContents.Replace("<this_pack> ", "");
                    o_folder_btn.Opacity = 1;


                    project_name.Text = trim_f;
                    if (File.Exists(filePath__))
                    {

                        
                        directory.Text = filePath__;
                            view1.Source = new Uri(filePath__, UriKind.Absolute);
                            link_webview.Text = filePath__;

                            //第1引数に読み込むファイルパス 第2引数に文字コードを指定
                            StreamReader strd = new StreamReader(filePath__, Encoding.GetEncoding("UTF-8"));

                            // 読み込み
                            textEditor.Text = strd.ReadToEnd();

                            // close
                            strd.Close();

                        
                            // テキストファイルのパス
                            string outputFilePath = "pkg_data.udapp";

                            // ファイルに書き込む
                            using (StreamWriter sw = new StreamWriter(outputFilePath))
                            {
                                sw.Write("<this_pack> L1"); // WriteLineではなくWriteを使用
                            }

                        package_message.Visibility = Visibility.Visible;
                    }



                    }

              

            }
        }


        private void teigi()
        {
            // アニメーションの定義
            _loaderAnimation = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 10,
                To = 550,
                Duration = TimeSpan.FromSeconds(1.5),
                RepeatBehavior = RepeatBehavior.Forever
            };
            Storyboard.SetTarget(animation, loader);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Canvas.Left)"));
            _loaderAnimation.Children.Add(animation);



            view1.Source = new Uri("https://ku-daa.web.app/fce/st/", UriKind.Absolute);

            SearchPanel.Install(textEditor.TextArea);

        }

       
        private void package_yes__btn(object sender, RoutedEventArgs e)
        {
            // テキストファイルのパス
            string outputFilePath = "pkg_data.udapp";

            // ファイルに書き込む
            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                sw.Write("<this_pack> [open]package1"); // WriteLineではなくWriteを使用
            }

            package_message.Visibility = Visibility.Hidden;

        }

        private void package_no__btn(object sender, RoutedEventArgs e)
        {
            // テキストファイルのパス
            string outputFilePath = "pkg_data.udapp";

            // ファイルに書き込む
            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                sw.Write("<this_pack> L1"); // WriteLineではなくWriteを使用
            }

            package_message.Visibility = Visibility.Hidden;

        }

        private void o_folder(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", directoryPath);


        }

        private void project_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


