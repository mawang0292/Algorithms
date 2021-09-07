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
            string s = "02984";
            string s1 = "567";
            Console.WriteLine("곱하기 혹은 더하기 문제 : " + Algorithms.Problem.Greed.Greed.MultiplyOrAdd_0(s));
            Console.WriteLine("곱하기 혹은 더하기 문제 : " + Algorithms.Problem.Greed.Greed.MultiplyOrAdd_0(s1));
            Console.WriteLine("곱하기 혹은 더하기 문제 : " + Algorithms.Problem.Greed.Greed.MultiplyOrAdd_1(s));
            Console.WriteLine("곱하기 혹은 더하기 문제 : " + Algorithms.Problem.Greed.Greed.MultiplyOrAdd_1(s1));
        }
    }
}
