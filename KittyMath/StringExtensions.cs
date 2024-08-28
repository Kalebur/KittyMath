namespace KittyMath
{
    public static class StringExtensions
    {
        public static decimal ConvertToNumber(this string sentence)
        {
            /* 
             * Create a dictionary to map the numeric words to their
             * integer equivalent 
            */

            Dictionary<string, int> numberMap = new()
            {
                { "zero", 0 },
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };

            /* To remove any issues with words not being detected
             * correctly due to their casing, we'll convert the
             * entire sentence to the same case. Since we used lowercase
             * words for our dictionary keys, we'll convert the sentence
             * to lowercase. We'll also use any leading or trailing whitespaces
             * using the Trim() method.
            */
            sentence = sentence.Trim().ToLower();

            /* 
             * Loop through each of the keys, or words, in the dicionary
             * and replace all occurrences of it in our sentence with its
             * integer equivalent.
             */
            foreach (var word in numberMap.Keys)
            {
                /*
                 * Because the number in the dictionary is an int, not a string,
                 * we have to convert it back to a string before we can update
                 * the sentence. Sentence itself is a string, and you can't mix
                 * types.
                */
                sentence = sentence.Replace(word, numberMap[word].ToString());
            }

            /* 
             * At this point, we've replaced every numeric word in the sentence
             * with an actual number, but the sentence is still a string. We want
             * it to be a decimal value instead, so we have to run it through the
             * Decimal.Parse method to get that, and we're just returning that value.
            */

            return Decimal.Parse(sentence);
        }
    }
}
