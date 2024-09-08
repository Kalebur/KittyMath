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

        public decimal ConvertDaysToHours(decimal days)
        {
            return Math.Round(days * 24, 2);
        }

        public decimal ConvertDaysToMinutes(decimal days)
        {
            var hours = ConvertDaysToHours(days);
            return Math.Round(hours * 60, 2);
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

            return Math.Round(months + (days / daysPerMonth[endingMonth]), 2);
        }

        public decimal ConvertDaysToSeconds(decimal days)
        {
            var hours = ConvertDaysToHours(days);
            return ConvertHoursToSeconds(hours);
        }

        public decimal ConvertDaysToYears(decimal days)
        {
            return Math.Round(days / 365, 2);
        }

        public decimal ConvertHoursToDays(decimal hours)
        {
            return Math.Round(hours / 24, 2);
        }

        public decimal ConvertHoursToMinutes(decimal hours)
        {
            return Math.Round(hours * 60, 2);
        }

        public decimal ConvertHoursToMonths(decimal hours)
        {
            var days = ConvertHoursToDays(hours);
            return ConvertHoursToMonths(days);
        }

        public decimal ConvertHoursToSeconds(decimal hours)
        {
            var minutes = ConvertHoursToMinutes(hours);
            return Math.Round(minutes * 60, 2);
        }

        public decimal ConvertHoursToYears(decimal hours)
        {
            var days = ConvertHoursToDays(hours);
            return ConvertHoursToYears(days);
        }

        public decimal ConvertMinutesToDays(decimal minutes)
        {
            var hours = ConvertMinutesToHours(minutes);
            return ConvertHoursToDays(hours);
        }

        public decimal ConvertMinutesToHours(decimal minutes)
        {
            return Math.Round(minutes / 60, 2);
        }

        public decimal ConvertMinutesToMonths(decimal minutes)
        {
            var days = ConvertMinutesToDays(minutes);
            return ConvertDaysToMonths(days);
        }

        public decimal ConvertMinutesToSeconds(decimal minutes)
        {
            return Math.Round(minutes * 60, 2);
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
            return Math.Round(seconds / 60, 2);
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
            return Math.Round(years * 12, 2);
        }

        public decimal ConvertYearsToSeconds(decimal years)
        {
            var minutes = ConvertYearsToMinutes(years);
            return ConvertMinutesToSeconds(minutes);
        }
    }
}
