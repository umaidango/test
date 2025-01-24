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

namespace fox_code_editor
{
    /// <summary>
    /// messagebox_yes_no.xaml の相互作用ロジック
    /// </summary>
    public partial class messagebox_yes_no : UserControl
    {
        public messagebox_yes_no()
        {
            InitializeComponent();
        }

        private void close(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Hidden; 
        }

        private void yes(object sender, RoutedEventArgs e)
        {

        }

        private void no(object sender, RoutedEventArgs e)
        {

        }
    }
}
