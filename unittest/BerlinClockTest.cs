using System;
using Xunit;
using Chaiwatmat.BerlinClock;

namespace Chaiwatmat.BerlinClock.Test
{
    // R = Red
    // Y = Yellow
    // O = Off

    public class BerlinClockTest
    {
        private BerlinClock _berlinClock;

        [Theory]
        [InlineData("Y")]
        public void WhenSecondsIsEven_TopClockShouldYellow(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopClock();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("O")]
        public void WhenSecondsIsNotEven_TopClockShouldOff(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 0, 59);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopClock();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("OOOO")]
        public void WhenHoursMidNight_TopHoursClockShouldAllOff(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopHoursClock();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("YYYY")]
        public void WhenHours11Pm_TopHoursClockShouldBeYYYY(string expected){
            var datetime = new DateTime(2017, 1, 1, 23, 59, 59);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopHoursClock();
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("YYOO")]
        public void WhenHours2Am_BottomHoursClockShouldYYOO(string expected){
            var datetime = new DateTime(2017, 1, 1, 2, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetBottomHoursClock();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("OOOO")]
        public void WhenHours5Am_BottomHoursClockShouldOOOO(string expected){
            var datetime = new DateTime(2017, 1, 1, 5, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetBottomHoursClock();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("YYYY")]
        public void WhenHours4Am_BottomHoursClockShouldYYYY(string expected){
            var datetime = new DateTime(2017, 1, 1, 4, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetBottomHoursClock();
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("OOOOOOOOOOO")]
        public void WhenMinutesZero_TopMinutesClockShouldAllOff(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopMinutesClock();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("YYOOOOOOOOO")]
        public void WhenMinutesTen_TopMinutesClockFirst2ShouldYY(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 10, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopMinutesClock();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("YYROOOOOOOO")]
        public void WhenMinutesNineteen_TopMinutesClockShouldStartWithYYROOO(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 19, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopMinutesClock();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("YYRYYRYYRYY")]
        public void WhenMinutesFiftyNine_TopMinutesClockShouldYYRYYRYYRYY(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 59, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopMinutesClock();
            Assert.Equal(expected, result);
        }



        [Theory]
        [InlineData("OOOO")]
        public void WhenMinutesZero_BottomMinutesClockShouldOff(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetBottomMinutesClock();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("YYYY")]
        public void WhenMinutesZero_BottomMinutesClockShouldAllY(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 59, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetBottomMinutesClock();
            Assert.Equal(expected, result);
        }

    }
}
