using System;
using DataStructures.Trees;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BSTNode<int> a = new BSTNode<int>();
            BSTNode<int> b = new BSTNode<int>();
            BSTNode<int> c = new BSTNode<int>();

            a.Value = 5;
            b.Value = 3;
            c.Value  = 7;

            a.LeftChild = b;
            a.RightChild = c;

            Console.WriteLine(a.Value);
            Console.WriteLine(b.Value);
            Console.WriteLine(c.Value);

            Console.WriteLine(a.IsLeafNode);
            Console.WriteLine(a.HasChildren);
            Console.WriteLine(a.HasLeftChild);
            Console.WriteLine(a.HasRightChild);
        }
    }
}
