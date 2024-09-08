namespace TimeConverter
{
    internal interface ITimeConverter
    {
        // Conversion to years
        decimal ConvertDaysToYears(decimal days);
        decimal ConvertMonthsToYears(decimal months);
        decimal ConvertHoursToYears(decimal hours);
        decimal ConvertMinutesToYears(decimal minutes);
        decimal ConvertSecondsToYears(decimal seconds);

        // Conversion to months
        decimal ConvertYearsToMonths(decimal years);
        decimal ConvertDaysToMonths(decimal days);
        decimal ConvertHoursToMonths(decimal hours);
        decimal ConvertMinutesToMonths(decimal minutes);
        decimal ConvertSecondsToMonths(decimal seconds);

        // conversion to days
        decimal ConvertYearsToDays(decimal years);
        decimal ConvertMonthsToDays(decimal months);
        decimal ConvertHoursToDays(decimal hours);
        decimal ConvertMinutesToDays(decimal minutes);
        decimal ConvertSecondsToDays(decimal seconds);

        // Conversion to hours
        decimal ConvertYearsToHours(decimal years);
        decimal ConvertMonthsToHours(decimal months);
        decimal ConvertDaysToHours(decimal days);
        decimal ConvertMinutesToHours(decimal minutes);
        decimal ConvertSecondsToHours(decimal seconds);

        // Conversion to minutes
        decimal ConvertYearsToMinutes(decimal years);
        decimal ConvertMonthsToMinutes(decimal months);
        decimal ConvertDaysToMinutes(decimal days);
        decimal ConvertHoursToMinutes(decimal hours);
        decimal ConvertSecondsToMinutes(decimal seconds);

        // Conversion to seconds
        decimal ConvertYearsToSeconds(decimal years);
        decimal ConvertMonthsToSeconds(decimal months);
        decimal ConvertDaysToSeconds(decimal days);
        decimal ConvertHoursToSeconds(decimal hours);
        decimal ConvertMinutesToSeconds(decimal minutes);

    }
}
