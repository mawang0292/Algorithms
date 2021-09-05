using System;
using DataStructures.Trees;

using Algorithms.Problem.Greed;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Greed greed = new Greed();
            Console.WriteLine("거스름 돈의 동전의 최소 갯수 구하기");
            
            Console.WriteLine("거스름 돈" + greed.Change(1260));
            Console.WriteLine("거스름 돈" + greed.Change(3480));
        }
    }
}
