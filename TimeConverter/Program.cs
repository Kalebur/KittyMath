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

using TimeConverter;

var input = "1942y 32d 07h 03m 42s";
var input2 = "314s";
var unitConverter = new UnitConverter();
var timeConverter = new UnitProcessor(new UnitAssigner(unitConverter), unitConverter);

//var result = timeConverter.SimpleConvertFromString(input2);
var result = timeConverter.ConvertFromString(input);
DisplayConversionResult(result, input);

void DisplayConversionResult(Dictionary<char, decimal> result, string input)
{
    Console.WriteLine($"Given input: {input}");
    Console.WriteLine();
    Console.WriteLine("Output:");
    Console.WriteLine($"\t{(int)result['y']} Year(s)");
    if (result.ContainsKey('M'))
    {
        Console.WriteLine($"\t{(int)result['M']} Month(s)");
    }
    Console.WriteLine($"\t{(int)result['d']} Day(s)");
    Console.WriteLine($"\t{(int)result['h']} Hour(s)");
    Console.WriteLine($"\t{(int)result['m']} Minute(s)");
    Console.WriteLine($"\t{(int)result['s']} Second(s)");
}