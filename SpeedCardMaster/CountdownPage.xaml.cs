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
using System.IO;
namespace SpeedCardMaster
{
    /// <summary>
    /// Interaction logic for CountdownPage.xaml
    /// </summary>
    public partial class CountdownPage : Page
    {
        public CountdownPage(double memorizationSpeed)
        {
            InitializeComponent();

            var shuffledCardBrushes = new List<Brush>(52);

            var cardBrushes = new List<Brush>(52);
            var files = Directory.GetFiles($"{AppContext.BaseDirectory}Images");
            foreach (var file in files)
            {
                cardBrushes.Add(new ImageBrush(new BitmapImage(new Uri(file))));
            }
            var rand = new Random();
            do
            {
                int removedIndex = rand.Next(0, cardBrushes.Count);
                shuffledCardBrushes.Add(cardBrushes[removedIndex]);
                cardBrushes.RemoveAt(removedIndex);
            }
            while (cardBrushes.Any());

            var countdownTilStartTimer = new System.Timers.Timer(1000);
            countdownTilStartTimer.AutoReset = true;
            countdownTilStartTimer.Elapsed += (s, e) =>
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    counterTB.Text = (int.Parse(counterTB.Text) - 1).ToString();
                    if (counterTB.Text == "0")
                    {
                        this.NavigationService.Navigate(new MemorizationPage(shuffledCardBrushes, memorizationSpeed));
                        memoryStartCountdownTB.Visibility = Visibility.Hidden;
                        counterTB.Visibility = Visibility.Hidden;
                        countdownTilStartTimer.Stop();
                    }
                }));
            };
            countdownTilStartTimer.Start();
        }
    }
}
