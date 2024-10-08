﻿namespace KittyMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PerformKittyMath();
        }

        private static void PerformKittyMath()
        {
            /* 
             
            Kitty Tiger Strikes Again.  You probably shouldn't have let Kitty 
            help you balance your bank books.  It seems that Kitty wrote all
            your numbers down half the time, and the other half of the time 
            Kitty wrote the numbers as words.

            Write a string extension method that will convert Kitty's scribblings 
            into decimal numbers.

            */

            string scribblings = "TwO3zErO1SeVEn.EightNine";
            decimal number = scribblings.ConvertToNumber();

            Console.WriteLine($"Your Bank Balance is: ${number}");
        }

        private static void PerformFranklinDecoding()
        {
            string encodedMessage = "ehT sleehw no eht sub og dnuor dna !dnuor";

            Console.WriteLine($"The Franklin encoded message is: {encodedMessage}");
            Console.WriteLine($"The decoded Franklin message is: {encodedMessage.Franklin()}");
        }
    }
}
