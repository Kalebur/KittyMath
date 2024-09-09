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
var input2 = "340000000d";
var timeConverter = new TimeConverter.TimeConverter();
//var convertedValues = timeConverter.ConvertFromString(input2);
//Console.WriteLine($"Given input: {input2}");
//Console.WriteLine();
//Console.WriteLine("Output:");
//Console.WriteLine($"\t{convertedValues.years} Year(s)");
//Console.WriteLine($"\t{convertedValues.months} Month(s)");
//Console.WriteLine($"\t{convertedValues.days} Day(s)");
//Console.WriteLine($"\t{convertedValues.hours} Hour(s)");
//Console.WriteLine($"\t{convertedValues.minutes} Minute(s)");
//Console.WriteLine($"\t{convertedValues.seconds} Second(s)");

var result = timeConverter.SimpleConvertFromString(input2);
DisplayConversionResult(result, input2);

void DisplayConversionResult(Dictionary<char, int> result, string input2)
{
    Console.WriteLine($"Given input: {input2}");
    Console.WriteLine();
    Console.WriteLine("Output:");
    Console.WriteLine($"\t{result['y']} Year(s)");
    if (result.ContainsKey('M'))
    {
        Console.WriteLine($"\t{result['M']} Month(s)");
    }
    Console.WriteLine($"\t{result['d']} Day(s)");
    Console.WriteLine($"\t{result['h']} Hour(s)");
    Console.WriteLine($"\t{result['m']} Minute(s)");
    Console.WriteLine($"\t{result['s']} Second(s)");
}