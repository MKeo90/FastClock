using System;
using System.Windows;
using EventsDemo.FastClock;

namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        EventsDemo.FastClock.FastClock fastClock;


        public MainWindow()
        {
            InitializeComponent();

            fastClock = new EventsDemo.FastClock.FastClock(DateTime.Now);
            fastClock.OneMinuteIsOver += FastClockOneMinuteIsOver;

        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
            DatePickerDate.SelectedDate = DateTime.Today;
            TextBoxTime.Text = DateTime.Now.ToShortTimeString();
        }

        private void ButtonSetTime_Click(object sender, RoutedEventArgs e)
        {
            // Hier wird die Beschleunigung gesetzt

            int number;
            int.TryParse(TextBoxFactor.Text.ToString(), out number);

            int convertedNumber = number;
            fastClock.Accelerator = convertedNumber;
        }

        private void SetFastClockStartDateAndTime()
        {
            //fastClock.CurrentTime = DatePickerDate.SelectedDate;
        }

        private void FastClockOneMinuteIsOver(object sender, DateTime fastClockTime)
        {
            TextBlockTime.Text = $"Aktuelle Zeit: {fastClockTime.ToShortTimeString()}";
        }

        private void CheckBoxClockRuns_Click(object sender, RoutedEventArgs e)
        {
            fastClock.IsRunning = CheckBoxClockRuns.IsChecked == true;
        }

        private void ButtonCreateView_Click(object sender, RoutedEventArgs e)
        {
            DigitalClock digitalClock = new DigitalClock();
            digitalClock.Owner = this;
            digitalClock.Show();

            fastClock.OneMinuteIsOver += digitalClock.DigitalClockOneMinuteIsOver;
        }
    }
}
