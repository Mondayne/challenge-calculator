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
            List<string> customDelimiterList = new List<string>();
            if (input.Length > 5)
            {                
                // Check for custom bracketed delimiter format //[{delimiter}]\n{numbers}
                if (input.Substring(0, 3) == "//[" && input.Substring(3).Contains(']'))
                {
                    int delimiterEndMarker = input.IndexOf(']');
                    // Check for requirement case 7 and 8.
                    if (input.Substring(delimiterEndMarker+1, 1) == "\n" || input.Substring(delimiterEndMarker + 1, 1) == "[")
                    {
                        customDelimiterList.Add(input.Substring(3, delimiterEndMarker-3));
                    }
                    // Check for more instances of custom delimiters after the first: //[{delimiter1}][{delimiter2}]...\n{numbers}
                    int leftMarker = 0;
                    int rightMarker = 0;
                    for (int i = delimiterEndMarker+1; i < input.Length; i++)
                    {                       
                        if (input[i] == '[' && rightMarker == 0)
                        {
                            leftMarker = i;
                        }
                        if (input[i] == ']' && leftMarker != 0)
                        {
                            rightMarker = i;
                        }
                        if (leftMarker != 0 && rightMarker != 0)
                        {
                            customDelimiterList.Add(input.Substring(leftMarker + 1, rightMarker - leftMarker - 1));
                            leftMarker = 0;
                            rightMarker = 0;
                        }
                    }
                }                
                // Check for custom char delimiter //{delimiter}\n{numbers}.
                if (input.ElementAt(0) == '/' && input.ElementAt(1) == '/' && input.ElementAt(3) == '\n')
                {
                    customDelimiterList.Add(input.ElementAt(2).ToString());
                }
            }

            // Split string by all delimiter types.
            foreach (var delimiter in customDelimiterList)
            {
                input = input.Replace(delimiter, ",");
            }
            input = input.Replace('\n', ',');           
            return input.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
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
