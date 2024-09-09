using System.Text.RegularExpressions;

namespace TimeConverter
{
    public class TimeConverter : ITimeConverter
    {
        private readonly Dictionary<int, int> daysPerMonth = new Dictionary<int, int>()
            {
                {1, 31},
                {2, 28},
                {3, 31},
                {4, 30},
                {5, 31},
                {6, 30},
                {7, 31},
                {8, 31},
                {9, 30},
                {10, 31},
                {11, 30},
                {12, 31},
            };

        private readonly Dictionary<char, decimal> _unitsByUnitCode = new()
            {
                {'y', 0 },
                {'d', 0 },
                {'h', 0 },
                {'m', 0 },
                {'s', 0 },
            };

        public Dictionary<char, decimal> ConvertFromString(string input)
        {
            var valuesFromString = input.Split(" ");

            decimal combinedSeconds = 0;
            foreach (var value in valuesFromString)
            {
                combinedSeconds += ConvertToSeconds(value);
            }

            decimal convertedMinutes = ConvertSecondsToMinutes(combinedSeconds);
            AssignConvertedValues('m', 's', convertedMinutes, ConvertMinutesToSeconds);

            decimal convertedHours = ConvertMinutesToHours(_unitsByUnitCode['m']);
            AssignConvertedValues('h', 'm', convertedHours, ConvertHoursToMinutes);

            decimal convertedDays = ConvertHoursToDays(_unitsByUnitCode['h']);
            AssignConvertedValues('d', 'h', convertedDays, ConvertDaysToHours);

            decimal convertedMonths = ConvertDaysToMonths(_unitsByUnitCode['d']);
            AssignConvertedValues('M', 'd', convertedMonths, ConvertMonthsToDays);

            decimal convertedYears = ConvertMonthsToYears(_unitsByUnitCode['M']);
            AssignConvertedValues('y', 'M', convertedYears, ConvertYearsToMonths);

            var convertedValuesAsInputString = $"{_unitsByUnitCode['y']}y {_unitsByUnitCode['M']}M {_unitsByUnitCode['d']}d {_unitsByUnitCode['h']}h {_unitsByUnitCode['m']}m {_unitsByUnitCode['s']}s";
            Console.WriteLine(convertedValuesAsInputString);

            return _unitsByUnitCode;
        }

        private void AssignConvertedValues(char majorUnit, char minorUnit, decimal majorValue, Func<decimal, decimal> convertToMinor)
        {
            _unitsByUnitCode[majorUnit] = Math.Floor(majorValue);
            _unitsByUnitCode[minorUnit] = Math.Round(convertToMinor(majorValue - _unitsByUnitCode[majorUnit]));
        }

        public Dictionary<char, decimal> SimpleConvertFromString(string input)
        {
            _unitsByUnitCode.Remove('M');
            var valuesToConvert = input.Split(" ");
            Regex regex = new Regex(@"(\d+)([ydhms])");

            foreach (var value in valuesToConvert)
            {
                var unitType = value.Last();
                var unitCount = int.Parse(value[0..(value.Length - 1)]);
                _unitsByUnitCode[unitType] = unitCount;
            }

            var convertedValues = PerformSimpleConversion(_unitsByUnitCode);

            return convertedValues;
        }

        private Dictionary<char, decimal> PerformSimpleConversion(Dictionary<char, decimal> values)
        {
            // Convert seconds to minutes
            if (values['s'] >= 60) {
                var minutes = values['s'] / 60;
                var remainderSeconds = values['s'] % 60;

                values['m'] += minutes;
                values['s'] = remainderSeconds;
            }

            // Convert Minutes to hours
            if (values['m'] >= 60)
            {
                var hours = values['m'] / 60;
                var remainderMinutes = values['m'] % 60;

                values['h'] += hours;
                values['m'] = remainderMinutes;
            }

            // Convert Hours to days
            if (values['h'] >= 24)
            {
                var days = values['h'] / 24;
                var remainderHours = values['h'] % 24;

                values['d'] += days;
                values['h'] = remainderHours;
            }

            // Convert Days to years
            if (values['d'] >= 365)
            {
                var years = values['d'] / 365;
                var remainderDays = values['d'] % 365;

                values['y'] += years;
                values['d'] = remainderDays;
            }

            return values;
        }

        public decimal ConvertToSeconds(string input)
        {
            var value = decimal.Parse(string.Join("",
                input.Where(character => char.IsDigit(character) || character == '.')));
            var inputUnit = input.Last();

            switch (inputUnit)
            {
                case 'y':
                    return ConvertYearsToSeconds(value);

                case 'M':
                    return ConvertMonthsToSeconds(value);

                case 'd':
                    return ConvertDaysToSeconds(value);

                case 'h':
                    return ConvertHoursToSeconds(value);

                case 'm':
                    return ConvertMinutesToSeconds(value);

                case 's':
                    return value;

                default:
                    throw new ArgumentException("Received invalid conversion unit, " + value);
            }
        }

        public decimal ConvertDaysToHours(decimal days)
        {
            return days * 24;
        }

        public decimal ConvertDaysToMinutes(decimal days)
        {
            var hours = ConvertDaysToHours(days);
            return hours * 60;
        }

        public decimal ConvertDaysToMonths(decimal days)
        {
            int months = 0;
            int endingMonth = 1;

            while (days >= 28)
            {
                for (int i = 1; i < 13; i++)
                {
                    if (days >= daysPerMonth[i])
                    {
                        months++;
                        days -= daysPerMonth[i];
                    }
                    else
                    {
                        endingMonth = i;
                    }
                }
            }

            return months + (days / daysPerMonth[endingMonth]);
        }

        public decimal ConvertDaysToSeconds(decimal days)
        {
            var hours = ConvertDaysToHours(days);
            return ConvertHoursToSeconds(hours);
        }

        public decimal ConvertDaysToYears(decimal days)
        {
            return days / 365;
        }

        public decimal ConvertHoursToDays(decimal hours)
        {
            return hours / 24;
        }

        public decimal ConvertHoursToMinutes(decimal hours)
        {
            return  hours * 60;
        }

        public decimal ConvertHoursToMonths(decimal hours)
        {
            var days = ConvertHoursToDays(hours);
            return ConvertDaysToMonths(days);
        }

        public decimal ConvertHoursToSeconds(decimal hours)
        {
            var minutes = ConvertHoursToMinutes(hours);
            return minutes * 60;
        }

        public decimal ConvertHoursToYears(decimal hours)
        {
            var days = ConvertHoursToDays(hours);
            return ConvertDaysToYears(days);
        }

        public decimal ConvertMinutesToDays(decimal minutes)
        {
            var hours = ConvertMinutesToHours(minutes);
            return ConvertHoursToDays(hours);
        }

        public decimal ConvertMinutesToHours(decimal minutes)
        {
            return minutes / 60;
        }

        public decimal ConvertMinutesToMonths(decimal minutes)
        {
            var days = ConvertMinutesToDays(minutes);
            return ConvertDaysToMonths(days);
        }

        public decimal ConvertMinutesToSeconds(decimal minutes)
        {
            return minutes * 60;
        }

        public decimal ConvertMinutesToYears(decimal minutes)
        {
            var days = ConvertMinutesToDays(minutes);
            return ConvertDaysToYears(days);
        }

        public decimal ConvertMonthsToDays(decimal months)
        {
            decimal days = 0;
            while (months >= 12)
            {
                for (int i = 1; i <= 12; i++)
                {
                    days += daysPerMonth[i];
                    months--;
                }
            }

            for (int i = 1; i <= months; i++)
            {
                days += daysPerMonth[i];
            }

            int nextMonth = (int)(months % 12) + 1;
            var fractionalMonth = months - Math.Floor(months);
            days += fractionalMonth * daysPerMonth[nextMonth];

            return Math.Round(days, 2);
        }

        public decimal ConvertMonthsToHours(decimal months)
        {
            var days = ConvertMonthsToDays(months);
            return ConvertDaysToHours(days);
        }

        public decimal ConvertMonthsToMinutes(decimal months)
        {
            var days = ConvertMonthsToDays(months);
            var hours = ConvertDaysToHours(days);
            return ConvertHoursToMinutes(hours);
        }

        public decimal ConvertMonthsToSeconds(decimal months)
        {
            var minutes = ConvertMonthsToMinutes(months);
            return ConvertMinutesToSeconds(minutes);
        }

        public decimal ConvertMonthsToYears(decimal months)
        {
            var days = ConvertMonthsToDays(months);
            return ConvertDaysToYears(days);
        }

        public decimal ConvertSecondsToDays(decimal seconds)
        {
            var hours = ConvertSecondsToHours(seconds);
            return ConvertHoursToDays(hours);
        }

        public decimal ConvertSecondsToHours(decimal seconds)
        {
            var minutes = ConvertSecondsToMinutes(seconds);
            return ConvertMinutesToHours(minutes);
        }

        public decimal ConvertSecondsToMinutes(decimal seconds)
        {
            return seconds / 60;
        }

        public decimal ConvertSecondsToMonths(decimal seconds)
        {
            var days = ConvertSecondsToDays(seconds);
            return ConvertDaysToMonths(days);
        }

        public decimal ConvertSecondsToYears(decimal seconds)
        {
            var days = ConvertSecondsToDays(seconds);
            return ConvertDaysToYears(days);
        }

        public decimal ConvertYearsToDays(decimal years)
        {
            var months = ConvertYearsToMonths(years);
            return ConvertMonthsToDays(months);
        }

        public decimal ConvertYearsToHours(decimal years)
        {
            var days = ConvertYearsToDays(years);
            return ConvertDaysToHours(days);
        }

        public decimal ConvertYearsToMinutes(decimal years)
        {
            var hours = ConvertYearsToHours(years);
            return ConvertHoursToMinutes(hours);
        }

        public decimal ConvertYearsToMonths(decimal years)
        {
            return years * 12;
        }

        public decimal ConvertYearsToSeconds(decimal years)
        {
            var minutes = ConvertYearsToMinutes(years);
            return ConvertMinutesToSeconds(minutes);
        }
    }
}
