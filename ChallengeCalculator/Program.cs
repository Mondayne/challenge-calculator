﻿using System;

namespace ChallengeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculator.Add("20"));
            Console.WriteLine(Calculator.Add("1, 5000"));
            Console.WriteLine(Calculator.Add("2,"));
            Console.WriteLine(Calculator.Add("1, l;ijk"));
            Console.WriteLine(Calculator.Add("1,2,3,4,5,6,7,8,9,10,11,12"));
            Console.WriteLine(Calculator.Add("1\n2,3"));
            Console.WriteLine(Calculator.Add("2,1001,6"));
            Console.WriteLine(Calculator.Add("//#\n2#5"));
            Console.WriteLine(Calculator.Add("//,\n2,ff,100"));
            Console.WriteLine(Calculator.Add("//[***]\n11***22***33"));
            Console.WriteLine(Calculator.Add("//[*][!!][r9r]\n11r9r22*hh*33!!44"));
            Console.ReadKey();
        }
    }
}
