using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using phiPartners.Helpers;

namespace phiPartners
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private APIWrapper apiWrapper = new APIWrapper();

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await this.LoadData();
        }

        private async Task LoadData()
        {
            this.gridHackerStories.ItemsSource = null;
            var dataSource = await apiWrapper.GetHackerStories();
            this.gridHackerStories.ItemsSource = dataSource;
        }

        private void Grid_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink link = (Hyperlink)e.OriginalSource;
            Process.Start(new ProcessStartInfo(link.NavigateUri.AbsoluteUri) { UseShellExecute = true });
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await this.LoadData();
        }
    }
}
