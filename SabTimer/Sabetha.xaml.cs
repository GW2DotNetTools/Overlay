using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Threading;
using Tesseract;

namespace SabTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Sabetha : Window
    {
        private DispatcherTimer timer;
        private DispatcherTimer timer2;
        private int counter;
        private int timing;

        private List<string> items = new List<string> { "South", "West", "North", "East", "South", "North", "West", "East" };

        public Sabetha()
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            label.Content = items[counter];
            timing = 30;
            if (counter == 7)
            {
                counter = 0;
                label2.Content = items[counter];
            }
            else
            {
                label2.Content = items[counter + 1];
                counter++;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            label2.Content = "started...";
            counter = 0;
            timing = 29;
            timer.Stop();
            timer2.Stop();
            timer.Start();
            timer2.Start();
        }

        private void button_Click1(object sender, RoutedEventArgs e)
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
