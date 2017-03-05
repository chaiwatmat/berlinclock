using System;
using NUnit.Framework;
using Chaiwatmat.BerlinClock;

namespace Chaiwatmat.BerlinClock.Test
{
    // R = Red
    // Y = Yellow
    // O = Off

    [TestFixture]
    public class BerlinClockTest
    {
        private BerlinClock _berlinClock;

        [TestCase("Y")]
        public void WhenSecondsIsEven_TopClockShouldYellow(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopClock();
            Assert.AreEqual(expected, result);
        }

        [TestCase("O")]
        public void WhenSecondsIsNotEven_TopClockShouldOff(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 0, 59);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopClock();
            Assert.AreEqual(expected, result);
        }

        [TestCase("OOOO")]
        public void WhenHoursMidNight_TopHoursClockShouldAllOff(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopHoursClock();
            Assert.AreEqual(expected, result);
        }

        [TestCase("YYYY")]
        public void WhenHours11Pm_TopHoursClockShouldBeYYYY(string expected){
            var datetime = new DateTime(2017, 1, 1, 23, 59, 59);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopHoursClock();
            Assert.AreEqual(expected, result);
        }


        [TestCase("YYOO")]
        public void WhenHours2Am_BottomHoursClockShouldYYOO(string expected){
            var datetime = new DateTime(2017, 1, 1, 2, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetBottomHoursClock();
            Assert.AreEqual(expected, result);
        }

        [TestCase("OOOO")]
        public void WhenHours5Am_BottomHoursClockShouldOOOO(string expected){
            var datetime = new DateTime(2017, 1, 1, 5, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetBottomHoursClock();
            Assert.AreEqual(expected, result);
        }

        [TestCase("YYYY")]
        public void WhenHours4Am_BottomHoursClockShouldYYYY(string expected){
            var datetime = new DateTime(2017, 1, 1, 4, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetBottomHoursClock();
            Assert.AreEqual(expected, result);
        }


        [TestCase("OOOOOOOOOOO")]
        public void WhenMinutesZero_TopMinutesClockShouldAllOff(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopMinutesClock();
            Assert.AreEqual(expected, result);
        }

        [TestCase("YYOOOOOOOOO")]
        public void WhenMinutesTen_TopMinutesClockFirst2ShouldYY(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 10, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopMinutesClock();
            Assert.AreEqual(expected, result);
        }

        [TestCase("YYROOOOOOOO")]
        public void WhenMinutesNineteen_TopMinutesClockShouldStartWithYYROOO(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 19, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopMinutesClock();
            Assert.AreEqual(expected, result);
        }

        [TestCase("YYRYYRYYRYY")]
        public void WhenMinutesFiftyNine_TopMinutesClockShouldYYRYYRYYRYY(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 59, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetTopMinutesClock();
            Assert.AreEqual(expected, result);
        }



        [TestCase("OOOO")]
        public void WhenMinutesZero_BottomMinutesClockShouldOff(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 0, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetBottomMinutesClock();
            Assert.AreEqual(expected, result);
        }

        [TestCase("YYYY")]
        public void WhenMinutesZero_BottomMinutesClockShouldAllY(string expected){
            var datetime = new DateTime(2017, 1, 1, 0, 59, 0);

            _berlinClock = new BerlinClock(datetime);
            var result = _berlinClock.GetBottomMinutesClock();
            Assert.AreEqual(expected, result);
        }

    }
}
