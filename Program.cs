using System;
using DataStructures.Trees;

using Algorithms.Problem;
using Algorithms.Problem.Greed;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 이 될때까지 수행된 최소 횟수 : "+Greed.UntilOne_0(25, 5));
            Console.WriteLine("1 이 될때까지 수행된 최소 횟수 : "+Greed.UntilOne_1(25, 5));
            Console.WriteLine("1 이 될때까지 수행된 최소 횟수 : "+Greed.UntilOne_2(25, 5));

            Console.WriteLine("1 이 될때까지 수행된 최소 횟수 : "+Greed.UntilOne_0(18, 5));
            Console.WriteLine("1 이 될때까지 수행된 최소 횟수 : "+Greed.UntilOne_1(18, 5));
            Console.WriteLine("1 이 될때까지 수행된 최소 횟수 : "+Greed.UntilOne_2(18, 5));
        }
    }
}
