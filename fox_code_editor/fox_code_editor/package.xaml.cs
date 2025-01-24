using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
using System.Windows.Shapes;

namespace fox_code_editor
{
    /// <summary>
    /// package.xaml の相互作用ロジック
    /// </summary>
    public partial class package : UserControl
    {
        double slider_value;
        public package()
        {
            InitializeComponent();
            LoadPackageDescription01();
        }


        private async void LoadPackageDescription01()
        {
            string url = "https://ku-daa.web.app/fce/package/store/fce_pack01.udapp";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string content = await client.GetStringAsync(url);
                    string content_2 = content.Replace("<k>", Environment.NewLine);

                    package_d_01.Content = content_2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("データの取得に失敗しました: " + ex.Message);
                }
            }
        }


        
        private void pkg_01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pkg_uz01.Visibility = Visibility.Visible;
        }
    }
}
