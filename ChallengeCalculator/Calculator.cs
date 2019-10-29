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
            // Convert input into string array.          
            string[] splitInput = input.Split(',', '\n');
            List<int> numberList = new List<int>();

            // Compute sum of items, if applicable.
            if (splitInput.Length == 0)
            {
                return "0";
            }
            else
            {
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
            }

            // Check if list contains any negative numbers and create list of bad elements if any are found.
            if (numberList.Exists(x => x < 0))
            {
                string badNumberList = CreateListOfNegativeInputs(numberList);
                throw new FormatException(badNumberList);
            }        

            return numberList.Sum().ToString();
        }

        /// <summary>
        /// Creates a list of numbers from a list of numbers that contains at least one negative element.
        /// </summary>
        /// <param name="numberList"></param>
        /// <returns></returns>
        private static string CreateListOfNegativeInputs(List<int> numberList)
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
