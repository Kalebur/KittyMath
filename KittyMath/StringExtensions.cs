using System.Text;

namespace KittyMath
{
    public static class StringExtensions
    {
        public static decimal ConvertToNumber(this string input)
        {
            /*
             * This will be the variable we will eventually return as
             * our final output. At the moment, we're just setting its
             * value to be the same as input. That will change shortly.
            */
            var convertedString = input;

            /* 
             * Create a dictionary to map the numeric words to their
             * actual numeric values
            */

            Dictionary<String, String> numberMap = new Dictionary<String, String>
            {
                { "zero", "0" },
                { "one", "1" },
                { "two", "2" },
                { "three", "3" },
                { "four", "4" },
                { "five", "5" },
                { "six", "6" },
                { "seven", "7" },
                { "eight", "8" },
                { "nine", "9" }
            };

            /* To remove any issues with words not being detected
             * correctly due to their casing, we'll convert the
             * entire sentence to the same case. Since we used lowercase
             * words for our dictionary keys, we'll convert the sentence
             * to lowercase. We'll also use any leading or trailing whitespaces
             * using the Trim() method.
            */
            convertedString = convertedString.Trim().ToLower();

            /* 
             * Here, we're looping through every entry in the dictionary
             * and converting the text form of a number to an actual number.
             */
            foreach (var numberAsWord in numberMap.Keys)
            {
                /*
                 * For each entry in the dictionary,numberAsWord becomes that entry's key.
                 * We want to find that value in input string and replace it with its
                 * number equivalent, which is what the numberMap[numberAsWord] statement
                 * is doing. It's going to the dictionary, finding the key that equals
                 * the current numberAsWord (let's say "zero", for example) and returning
                 * the value related to that key ("0"). The Replace method, then is saying
                 * "Hey, all instances of zero in the string that's calling Replace() should
                 * now be 0 instead. Here's a new string with those replacements made." We're
                 * storing that new string back into convertedString. If you don't assign it
                 * to a variable of some sort, the result of calling Replace() is just lost
                 * to the void.
                */
                convertedString = convertedString.Replace(numberAsWord, numberMap[numberAsWord]);
            }

            /* 
             * At this point, we've replaced every numeric word in the sentence
             * with an actual number, but the sentence is still a string. We want
             * it to be a decimal value instead, so we have to run it through the
             * Decimal.Parse method to get that, and we're just returning that value.
            */

            return Decimal.Parse(convertedString);
        }

        public static string Franklin(this string encodedMessage)
        {
            // Create a new list to store our words as we decode them
            var decodedWords = new List<string>();

            // Split the input (the encoded message) into individual words
            var encodedWords = encodedMessage.Split(" ");

            // Loop through each word
            foreach (var word in encodedWords)
            {
                /*
                 * Decode the word using the Decode method below and
                 * add it in the list of decoded words.
                */
                var decodedWord = word.Decode();
                decodedWords.Add(decodedWord);
            }

            /*
             * Join the list of decoded words back into a single string
             * with all the words separated by spaces and return the
             * new string.
            */ 
            return string.Join(" ", decodedWords);
        }

        private static string Decode(this string input)
        {
            var characters = input.ToCharArray();
            Array.Reverse(characters);

            /*
             * new string(characters) is a shorter way of converting the
             * characters array back into a combined string. It's the
             * equivalent of writing string.Join("", characters);
            */
            return new string(characters);
        }
    }
}
