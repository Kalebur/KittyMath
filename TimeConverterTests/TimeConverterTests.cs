namespace TimeConverterTests
{
    public class Tests
    {
        private TimeConverter.TimeConverter _timeConverter;

        [SetUp]
        public void Setup()
        {
            _timeConverter = new TimeConverter.TimeConverter();
        }

        [TestCase(31, 1)]
        [TestCase(59, 2)]
        [TestCase(90, 3)]
        [TestCase(120, 4)]
        [TestCase(151, 5)]
        [TestCase(181, 6)]
        [TestCase(212, 7)]
        [TestCase(243, 8)]
        [TestCase(273, 9)]
        [TestCase(304, 10)]
        [TestCase(334, 11)]
        [TestCase(365, 12)]
        [TestCase(61, 2.06)]
        public void ConvertDaysToMonths_ReturnsTheCorrectNumberOfMonthsRoundedToTwoPlaces(decimal numberOfDays, decimal expectedMonthCount)
        {
            var result = Math.Round(_timeConverter.ConvertDaysToMonths(numberOfDays), 2);

            Assert.That(result, Is.EqualTo(expectedMonthCount));
        }

        [TestCase(2, 48)]
        [TestCase(1, 24)]
        [TestCase(800, 19200)]
        [TestCase(31.5, 756)]
        [TestCase(31, 744)]
        [TestCase(19.145, 459.48)]
        public void ConvertDaysToHours_ReturnsTheCorrectNumberOfHours_RoundedToTwoPlaces(decimal numberOfDays, decimal expectedHours)
        {
            var result = Math.Round(_timeConverter.ConvertDaysToHours(numberOfDays), 2);

            Assert.That(result, Is.EqualTo(expectedHours));
        }

        [TestCase(1, 1440)]
        [TestCase(6.347, 9139.68)]
        public void ConvertDaysToMinutes_ReturnsTheCorrectNumberOfMinutes_RoundedToTwoPlaces(decimal numberOfDays, decimal expectedMinutes)
        {
            var result = Math.Round(_timeConverter.ConvertDaysToMinutes(numberOfDays), 2);

            Assert.That(result, Is.EqualTo(expectedMinutes));
        }

        [TestCase(1, 86400)]
        [TestCase(6.347, 548_380.8)]
        public void ConvertDaysToSeconds_ReturnsTheCorrectNumberOfSeconds_RoundedToTwoPlaces(decimal numberOfDays, decimal expectedSeconds)
        {
            var result = Math.Round(_timeConverter.ConvertDaysToSeconds(numberOfDays), 2);

            Assert.That(result, Is.EqualTo(expectedSeconds));
        }

        [TestCase(1, 31)]
        [TestCase(2, 59)]
        [TestCase(3, 90)]
        [TestCase(4, 120)]
        [TestCase(5, 151)]
        [TestCase(6, 181)]
        [TestCase(7, 212)]
        [TestCase(8, 243)]
        [TestCase(9, 273)]
        [TestCase(10, 304)]
        [TestCase(11, 334)]
        [TestCase(12, 365)]
        [TestCase(13, 396)]
        [TestCase(12.5, 380)]
        public void ConvertMonthsToDays_ReturnsTheExpectedNumberOfMonths(decimal numberOfMonths, decimal expectedDays)
        {
            var result = Math.Round(_timeConverter.ConvertMonthsToDays(numberOfMonths));

            Assert.That(result, Is.EqualTo(expectedDays));
        }

        [TestCase(60, 1)]
        [TestCase(180, 3)]
        [TestCase(600, 10)]
        [TestCase(1136, 18.93333333333)]
        [TestCase(2785, 46.41666666666)]
        public void ConvertSecondsToMinutes_ReturnsTheExpectedNumberOfMinutes(decimal numberOfSeconds, decimal expectedMinutes)
        {
            var result = _timeConverter.ConvertSecondsToMinutes(numberOfSeconds);

            Assert.That(result, Is.EqualTo(expectedMinutes).Within(0.003));
        }
    }
}