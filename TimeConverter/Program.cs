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

var unitConverter = new UnitConverter();
var unitProcessor = new UnitProcessor(new UnitAssigner(unitConverter), unitConverter);
var app = new App(unitProcessor);

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Something went wrong and the application has to close.\n", ex.Message);
}
