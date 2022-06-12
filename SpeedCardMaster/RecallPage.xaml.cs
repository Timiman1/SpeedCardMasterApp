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
    /// Interaction logic for RecallPage.xaml
    /// </summary>
    public partial class RecallPage : Page
    {
        List<Brush> _shuffledCardBrushes;
        int currentIndex;
        int rightCount = 0;
        readonly DateTime _recallStartTime;
        readonly double _memoSpeed;
        public RecallPage(List<Brush> shuffledCardBrushes, double memoSpeed)
        {
            InitializeComponent();
            _shuffledCardBrushes = shuffledCardBrushes;
            _recallStartTime = DateTime.Now;
            _memoSpeed = memoSpeed;
        }

        private void Right_Button_Click(object sender, RoutedEventArgs e)
        {
            PointsTB.Text = $"{++rightCount}/52";
            NextCard();
        }
        private void Wrong_Button_Click(object sender, RoutedEventArgs e)
        {
            NextCard();
        }

        private void Show_Button_Click(object sender, RoutedEventArgs e)
        {
            imageBorder.Background = _shuffledCardBrushes[currentIndex];
            showButton.IsEnabled = false;
            wrongButton.IsEnabled = true;
            rightButton.IsEnabled = true;
        }

        private void NextCard()
        {
            imageBorder.Background = Brushes.AliceBlue;
            currentIndex++;
            if (currentIndex == _shuffledCardBrushes.Count)
            {
                this.NavigationService.Navigate(new ResultPage(rightCount, DateTime.Now.Subtract(_recallStartTime), _memoSpeed));
                return;
            }
            showButton.IsEnabled = true;
            wrongButton.IsEnabled = false;
            rightButton.IsEnabled = false;
        }
    }
}
