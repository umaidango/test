using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
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
using Path = System.IO.Path;

namespace fox_code_editor
{
    /// <summary>
    /// package_unzip1.xaml の相互作用ロジック
    /// </summary>
    public partial class package_unzip1 : UserControl
    {
        public package_unzip1()
        {
            InitializeComponent();
            LoadPackageDescription();
        }

        private async void LoadPackageDescription()
        {
            string url = "https://ku-daa.web.app/fce/package/store/fce_pack01.udapp";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string content = await client.GetStringAsync(url);
                    string contentWithNewLines = content.Replace("<k>", Environment.NewLine);
                    package_d.Content = contentWithNewLines;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("データの取得に失敗しました: " + ex.Message);
                }
            }
        }

        private async void unzip(object sender, RoutedEventArgs e)
        {

            // ZIP ファイルの URL
            string zipFileUrl = "https://github.com/usoftware-gr/software-lineup/raw/refs/heads/main/fce/package/fce_pkg1.zip";

            // ダウンロードした ZIP ファイルを保存するローカルパス
            string localZipFilePath = Path.Combine(Path.GetTempPath(), "fce_pkg1.zip");

            // ZIP ファイルをダウンロード
            using (HttpClient client = new HttpClient())
            {
                byte[] zipFileBytes = await client.GetByteArrayAsync(zipFileUrl);
                await File.WriteAllBytesAsync(localZipFilePath, zipFileBytes);
            }

            // 解凍先のディレクトリ
            string extractDirectory = "package_unzip01";

            // 解凍先のディレクトリが存在しない場合は作成
            if (!Directory.Exists(extractDirectory))
            {
                Directory.CreateDirectory(extractDirectory);
            }

            // ZIP ファイルを開いて解凍
            using (ZipArchive archive = ZipFile.OpenRead(localZipFilePath))
            {
                archive.ExtractToDirectory(extractDirectory);
            }

            string fullPath = Path.Combine(Path.GetFullPath(extractDirectory), "fce_prj1");

            // テキストファイルのパス
            string outputFilePath = "pkg_data.udapp";

            // ファイルに書き込む
            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                sw.Write("<this_pack> package1"); // WriteLineではなくWriteを使用
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            
        }
    }
}
