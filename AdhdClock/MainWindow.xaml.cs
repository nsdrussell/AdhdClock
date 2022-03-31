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
using System.Windows.Threading;

namespace AdhdClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
         
        double secondsRemaining;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void closeLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


        private void SetTime(int seconds)
        {
            timer.Tick -= Timer_Time;
            
            this.secondsRemaining = seconds;
            timer.Stop();
            timer.Interval = new TimeSpan(0,0,1)  ; //update each second
            timer.Start();
            timer.Tick += Timer_Time;
            Timer_Time(null, new EventArgs());
        }

        private void Timer_Time(object? sender, EventArgs e)
        {
            var time = $"{(int)secondsRemaining / 60:00}:{secondsRemaining % 60:00}";
            timeLabel.Content = time;
            lineRotation.Angle = secondsRemaining-- / 10d;
        }

        private void canvasControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.SizeAll;
        }

        private void canvasControl_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void canvasControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void setHourTimeLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetTime(3600);
        }


        private void set30MinsTimeLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetTime(1800);
        }

        private void setTimeLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetTimeWindow setTimeWindow = new SetTimeWindow();
            setTimeWindow.ShowDialog();
            SetTime(setTimeWindow.Time);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Shape control in mainCanvas.Children.OfType<Shape>())
            {
                control.MouseEnter += canvasControl_MouseEnter;
                control.MouseLeave += canvasControl_MouseLeave;
                control.MouseDown += canvasControl_MouseDown;
            }
        }
    }
}
