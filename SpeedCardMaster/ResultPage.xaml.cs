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
    /// Interaction logic for ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage(int rightCount, TimeSpan recallDuration, double memoSpeed)
        {
            InitializeComponent();
            correctRecallsTB.Text = rightCount.ToString() + "/52 cards";
            var total = TimeSpan.FromSeconds(memoSpeed * 52);
            var formattedTotal = $"{(int)total.TotalMinutes}:{ total.Seconds:00} min:s";
            memoSpeedTB.Text = memoSpeed.ToString() + $" s/card\nIn total: {formattedTotal}";
            recallDurationTB.Text = $"{(int)recallDuration.TotalMinutes}:{recallDuration.Seconds:00} min:s"; ;
        }

        private void backToMainButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }
    }
}
