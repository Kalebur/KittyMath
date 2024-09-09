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
var input2 = "36499d 12M 24d 10h 94m 102s";
var unitConverter = new UnitConverter();
var timeConverter = new UnitProcessor(new UnitAssigner(unitConverter), unitConverter);

//var result = timeConverter.SimpleConvertFromString(input2);
var result = timeConverter.ConvertFromString(input2);
result = AdjustForLeapYears(result);
DisplayConversionResult(result, input2);

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

Dictionary<char, decimal> AdjustForLeapYears(Dictionary<char, decimal> inputValues)
{
    var leapDays = 0;

    for (int i = 0; i < inputValues['y']; i += 4)
    {
        if (IsLeapYear(i)) leapDays++;
    }

    var adjustedString = $"{inputValues['y']}y {inputValues['M']}M {inputValues['d']}d {inputValues['h']}h {inputValues['m']}m {inputValues['s']}s";
    return timeConverter.ConvertFromString(adjustedString);
}

bool IsLeapYear(int year)
{
    if (year % 4 == 0)
    {
        if (year % 100 == 0)
        {
            if (year % 400 == 0)
            {
                return true; // Divisible by 4, 100, and 400
            }
            else
            {
                return false; // Divisible by 4 and 100, but not 400
            }
        }
        else
        {
            return true; // Divisible by 4, but not 100
        }
    }
    else
    {
        return false; // Not divisible by 4
    }
}
