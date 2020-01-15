using System;
using System.Windows.Threading;

namespace EventsDemo.FastClock
{
    public class FastClock
    {

        private readonly DispatcherTimer _timer;
        public DateTime CurrentTime { get; set; }

        // =========================================================

        public void SetDate(DateTime date)
        {

        }


        public event EventHandler<DateTime> OneMinuteIsOver;

        protected virtual void OnOneMinuteIsOver(DateTime time)
        {
            OneMinuteIsOver?.Invoke(this, time);
        }


        // =========================================================
        private int _accelerator;

        public int Accelerator
        {
            get
            {
                return _accelerator;
            }

            set
            {
                _accelerator = value;

                _timer.Interval = TimeSpan.FromMilliseconds(0.277778 * value);

            }
        }

        public FastClock(DateTime currentTime)
        {
            CurrentTime = currentTime;
            _timer = new DispatcherTimer();
            _timer.Tick += OnTimerTick;     // Methode registrieren
            _timer.Interval = TimeSpan.FromMinutes(1 * 0.01);  // Intervall für den timer setzen
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            CurrentTime = CurrentTime.AddMinutes(1);
            OnOneMinuteIsOver(CurrentTime);
        }

        // =========================================================



        private bool _isRunning;

        public bool IsRunning
        {
            get => _isRunning;
            //get { return _isRunning; }

            set
            {
                if (!_isRunning && value)
                {
                    _timer.Start();
                }
                else if (_isRunning && value == false)
                {
                    _timer.Stop();
                }

                _isRunning = value;
            }
        }
    }
}
