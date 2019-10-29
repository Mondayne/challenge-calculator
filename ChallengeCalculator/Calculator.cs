using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallengeCalculator
{
    public class Calculator
    {
        public static string Add(string input)
        {
            List<string> splitInput = GetListOfDelimitedInputs(input);
            List<int> numberList = new List<int>();

            // Create list of ints from string list if it contains items.
            if (splitInput.Count == 0)
            {
                return "0";
            }
            else
            {
                numberList = GetListOfIntsFromStringList(splitInput);
            }

            // Check if list contains any negative numbers and create list of bad elements if any are found.
            if (numberList.Exists(x => x < 0))
            {
                string badNumberList = GetListOfNegativeInputs(numberList);
                throw new FormatException(badNumberList);
            }

            return numberList.Sum().ToString();
        }

        /// <summary>
        /// Create a list of integers from a list of strings.
        /// </summary>
        /// <param name="splitInput"></param>
        /// <returns></returns>
        private static List<int> GetListOfIntsFromStringList(List<string> splitInput)
        {
            List<int> numberList = new List<int>();
            foreach (var item in splitInput)
            {
                try
                {
                    int number = Int32.Parse(item);
                    if (number > 1000)
                    {
                        // numbers over 1000 are converted to 0 and ignored.
                    }
                    else
                        numberList.Add(number);
                }
                catch
                {
                    // Invalid input should be converted to 0, i.e. ignored.
                }
            }
            return numberList;
        }

        /// <summary>
        /// Create delimited list of strings from input string, checking for use of custom delimiter and then using standard delimiters of ',' and '\n'.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static List<string> GetListOfDelimitedInputs(string input)
        {
            // Check for custom delimiter usage.
            char customDelimiter;
            if (input.Length > 5)
            {
                if (input.ElementAt(0) == '/' && input.ElementAt(1) == '/' && input.ElementAt(3) == '\n')
                {
                    customDelimiter = input.ElementAt(2);
                    return input.Split(',', '\n', customDelimiter).ToList();
                }
            }           
        
            return input.Split(',', '\n').ToList();
        }

        /// <summary>
        /// Creates a list of numbers from a list of numbers that contains at least one negative element.
        /// </summary>
        /// <param name="numberList"></param>
        /// <returns></returns>
        private static string GetListOfNegativeInputs(List<int> numberList)
        {
            string badNumberList = "";
            foreach (var item in numberList.Where(x => x < 0))
            {
                if (badNumberList.Length > 0)
                {
                    badNumberList += $",{item}";
                }
                else
                    badNumberList = item.ToString();
            }

            return badNumberList;
        }

    }
}
