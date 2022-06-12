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

namespace SpeedCardMaster
{
    /// <summary>
    /// Interaction logic for MemorizationPage.xaml
    /// </summary>
    public partial class MemorizationPage : Page
    {
        System.Timers.Timer timer;
        public MemorizationPage(List<Brush> shuffledCardBrushes, double memorizationSpeed)
        {
            InitializeComponent();
            timer = new System.Timers.Timer(memorizationSpeed * 1000);
            timer.AutoReset = true;
            int currentIndex = 0;
            imageBorder.Background = shuffledCardBrushes[currentIndex++];
            timer.Elapsed += (s, e) =>
            {
                Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (currentIndex == shuffledCardBrushes.Count)
                    {
                        timer.Stop();
                        this.NavigationService.Navigate(new RecallPage(shuffledCardBrushes, memorizationSpeed));
                    }
                    else
                    {
                        imageBorder.Background = shuffledCardBrushes[currentIndex++];
                    }
                });
            };
            timer.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            this.NavigationService.Navigate(new MainPage());
        }
    }
}
