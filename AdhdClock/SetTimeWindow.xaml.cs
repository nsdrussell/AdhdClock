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
using System.Windows.Shapes;

namespace AdhdClock
{
    /// <summary>
    /// Interaction logic for SetTimeWindow.xaml
    /// </summary>
    public partial class SetTimeWindow : Window
    {
        public int Time { get; set; }

        public SetTimeWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            timeLabel.Content = $"{(int)e.NewValue} minutes";
            Time = (int)e.NewValue * 60;
            okButton.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}