namespace TimeConverter
{
    public class App
    {
        private UnitProcessor _unitProcessor;

        public App(UnitProcessor unitProcessor)
        {
            _unitProcessor = unitProcessor;
        }

        public void Run()
        {
            string userChoice = string.Empty;
            do
            {
                Console.WriteLine("Enter a string in the format Xy XM Xd Xh Xm Xs");
                Console.WriteLine("Where X is a number of (y)ears, (M)onths, (d)ays,\n" +
                    "\t(h)ours, (m)inutes and (s)econds");
                Console.Write("Enter your string: ");
                string userInput = Console.ReadLine();
                var result = _unitProcessor.ConvertFromString(userInput);
                result = AdjustForLeapYears(result);
                DisplayConversionResult(result, userInput);

                Console.Write("Do you want to play again? y/n: ");
                userChoice = Console.ReadLine().Trim().ToLower();
            } while (userChoice != "n");

        }

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
            return _unitProcessor.ConvertFromString(adjustedString);
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
    }
}
