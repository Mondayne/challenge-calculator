﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeCalculator
{
    public class Calculator
    {
        public static string Add(string input)
        {
            // Convert input into string array.
            int result = 0;
            string[] splitInput = input.Split(',', '\n');

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
                        result += Int32.Parse(item);
                    }
                    catch
                    {
                        // Invalid input should be converted to 0, i.e. ignored.
                    }
                }
            }

            return result.ToString();
        }
    }
}
