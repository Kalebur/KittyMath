/* 
 * Write a console app that converts a string that represents an amount of time. Use the following characters 'y' for years, 'd' for days, 'h' for hours, 'm' for minutes and 's' for seconds. Skip using months (unless you like an additional challenge) for this exercise.

    Test Inputs:
    "1942y 113d 07h 03m 42s" 

        Test Output:
        xxxx years
        xxxx days
        xxxx hours
        xxxx minutes
        xxxx seconds
*/
var input = "1942y 113d 07h 03m 42s";
var input2 = "10y 8s";
var timeConverter = new TimeConverter.TimeConverter();
var convertedValues = timeConverter.ConvertFromString(input2);
//Console.WriteLine(timeConverter.ConvertHoursToYears(7));
Console.WriteLine($"Given input: {input2}");
Console.WriteLine();
Console.WriteLine("Output:");
Console.WriteLine($"\t{convertedValues.years} Years");
Console.WriteLine($"\t{convertedValues.months} Months");
Console.WriteLine($"\t{convertedValues.days} Days");
Console.WriteLine($"\t{convertedValues.hours} Hours");
Console.WriteLine($"\t{convertedValues.minutes} Minutes");
Console.WriteLine($"\t{convertedValues.seconds} Seconds");