using System;

namespace ChallengeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculator.Add("20"));
            Console.WriteLine(Calculator.Add("1, 5000"));
            Console.WriteLine(Calculator.Add("4,-3"));
            Console.WriteLine(Calculator.Add("2,"));
            Console.WriteLine(Calculator.Add("1, l;ijk"));
            Console.ReadKey();
        }
    }
}
