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

        public (decimal years, decimal months, decimal days, decimal hours,
            decimal minutes, decimal seconds) ConvertFromString(string input)
        {
            decimal years, months, days, hours, minutes, seconds;
            years = months = days = hours = minutes = seconds = 0;

            var valuesToConvert = input.Trim().Split(" ");

            decimal combinedYears = 0;
            foreach (var value in valuesToConvert)
            {
                combinedYears += Convert(value);
            }

            years = Math.Floor(combinedYears);
            decimal remainingMonths = ConvertYearsToMonths(combinedYears - years);
            months = Math.Floor(remainingMonths);
            decimal remainingDays = ConvertMonthsToDays(remainingMonths - months);
            days = Math.Floor(remainingDays);
            decimal remainingHours = ConvertDaysToHours(remainingDays - days);
            hours = Math.Floor(remainingHours);
            decimal remainingMinutes = ConvertHoursToMinutes(remainingHours - hours);
            minutes = Math.Floor(remainingMinutes);
            decimal remainingSeconds = ConvertMinutesToSeconds(remainingMinutes - minutes);
            seconds = Math.Floor(remainingSeconds);


            return (years, months, days, hours, minutes, seconds);
        }

        private decimal Convert(string input)
        {
            var value = decimal.Parse(string.Join("", 
                input.Where(character => char.IsDigit(character) || character == '.')));
            var inputUnit = input.Last();

            switch (inputUnit)
            {
                case 'y':
                    return value;

                case 'M':
                    return ConvertMonthsToYears(value);

                case 'd':
                    return ConvertDaysToYears(value);

                case 'h':
                    return ConvertHoursToYears(value);

                case 'm':
                    return ConvertMinutesToYears(value);

                case 's':
                    return ConvertSecondsToYears(value);

                default:
                    throw new ArgumentException("Received invalid conversion unit, " + value);
            }
        }

        //public (decimal years, decimal months, decimal days, decimal hours,
        //    decimal minutes, decimal seconds) ConvertToAll(string input)
        //{
        //    decimal years, months, days, hours, minutes, seconds;
        //    years = months = days = hours = minutes = seconds = 0;

        //    var regex = new Regex(@"(\d+\.?\d*)([yMdhms])");
        //    var matches = regex.Matches(input);

        //    foreach (Match match in matches)
        //    {
        //        var value = decimal.Parse(match.Groups[1].ToString());
        //        var startingUnit = match.Groups[2].ToString();

        //        switch (startingUnit)
        //        {
        //            case "y":
        //                years = value;
        //                months = ConvertYearsToMonths(value);
        //                days = ConvertYearsToDays(value);
        //                break;
        //        }
        //    }

        //    return (years, months, days, hours, minutes, seconds);
        //}

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
