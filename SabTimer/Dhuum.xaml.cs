using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Tesseract;

namespace SabTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dhuum : Window
    {
        private DispatcherTimer timer;
        private DispatcherTimer timer2;
        private int counter;
        private int timing;

        private List<string> items = new List<string>
        {
            "P1 Arrow", "P2 Circle", "P3 Heart", "P1 Square", "P2 Star", "P3 Spiral", "P1 Triangle",
            "P2 Arrow", "P3 Circle", "P1 Heart", "P2 Square", "P3 Star", "P1 Spiral", "P2 Triangle",
            "P3 Arrow", "P1 Circle", "P2 Heart", "P3 Square", "P1 Star"
        };

        public Dhuum()
        {
            InitializeComponent();
            this.timer = new DispatcherTimer();
            this.timer2 = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer2.Tick += (o, e) =>
            {
                time.Content = timing--;
            };
            counter = 0;
            timing = 30;
        }

        private SolidColorBrush GetColor(string content)
        {
            if (content.Contains("Arrow")) { return Brushes.LightGreen; }
            if (content.Contains("Circle")) { return Brushes.Purple; }
            if (content.Contains("Heart")) { return Brushes.Red; }
            if (content.Contains("Square")) { return Brushes.Blue; }
            if (content.Contains("Star")) { return Brushes.Green; }
            if (content.Contains("Spiral")) { return Brushes.LightBlue; }
            if (content.Contains("Triangle")) { return Brushes.MediumPurple; }

            return Brushes.LightGreen;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (counter == 19)
            {
                Stop();
            }

            label.Content = items[counter];
            label.Foreground = GetColor(items[counter]);

            timing = 30;
            if (counter < 17)
            {
                label2.Content = items[counter + 1];
                player3.Content = items[counter + 2];
                label2.Foreground = GetColor(items[counter + 1]);
                player3.Foreground = GetColor(items[counter + 2]);
            }
            else
            {
                label2.Content = string.Empty;
                player3.Content = string.Empty;
            }
            counter++;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "P1 Arrow";
            label.Foreground = Brushes.LightGreen;
            label2.Content = "P2 Circle";
            label2.Foreground = Brushes.Purple;
            player3.Content = "P3 Heart";
            player3.Foreground = Brushes.Red;

            counter = 0;
            timing = 29;
            timer.Stop();
            timer2.Stop();
            timer.Start();
            timer2.Start();
        }

        private void button_Click1(object sender, RoutedEventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            timer.Stop();
            timer2.Stop();
            timing = 30;
            counter = 0;
            label.Content = "Waiting";
            label2.Content = "to start...";
            time.Content = "30";
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
