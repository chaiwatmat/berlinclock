using System;

namespace Chaiwatmat.BerlinClock
{
    public class BerlinClock
    {
        private DateTime _currentDateTime;

        public BerlinClock(DateTime? datetime)
        {
            _currentDateTime = datetime ?? DateTime.Now;
        }

        public DateTime CurrentTime
        {
            get{
                return _currentDateTime;
            }
            set{
                _currentDateTime = DateTime.Now;
            }
        }

        public string GetTopClock(){
            return _currentDateTime.Second % 2 == 0 ? "Y" : "O";
        }

        public string GetTopHoursClock(){
            var signals = "";
            var hourQuarters = (int)Math.Floor(_currentDateTime.Hour / 5d);

            signals = signals.PadLeft(hourQuarters, 'Y');
            signals = signals.PadRight(4, 'O');

            return signals;
        }

        public string GetBottomHoursClock(){
            var signals = "";
            var hourQuarters = _currentDateTime.Hour % 5;

            signals = signals.PadLeft(hourQuarters, 'Y');
            signals = signals.PadRight(4, 'O');

            return signals;
        }



        public string GetTopMinutesClock(){
            var signals = "";
            var minuteRanges = (int)Math.Floor(_currentDateTime.Minute / 5d);

            for(var i = 1; i <= minuteRanges; i++){
                signals += i % 3 == 0 ? "R" : "Y";
            }
            signals = signals.PadRight(11, 'O');

            return signals;
        }

        public string GetBottomMinutesClock(){
            var signals = "";
            var minuteRanges = _currentDateTime.Minute % 5;

            signals = signals.PadLeft(minuteRanges, 'Y');
            signals = signals.PadRight(4, 'O');

            return signals;
        }
    }
}
