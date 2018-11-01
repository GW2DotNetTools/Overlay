using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Tesseract;

namespace SabTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RotationWeaver : Window
    {
        public RotationWeaver()
        {
            InitializeComponent();
        }


        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
        }
    }
}
