using System;

namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for DigitalClock.xaml
    /// </summary>
    public partial class DigitalClock
    {
        EventsDemo.FastClock.FastClock fastClock;

        public DigitalClock()
        {
            InitializeComponent();
        }

        public void DigitalClockOneMinuteIsOver(object sender, DateTime e)
        {
            TextBlockClock.Text = $"Aktuelle Zeit: {e.ToShortTimeString()}";
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            //fastClock = new EventsDemo.FastClock.FastClock(DateTime.Now);
            //fastClock.OneMinuteIsOver += DigitalClockOneMinuteIsOver;
        }

    }
}
