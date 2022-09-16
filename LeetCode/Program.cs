
using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var strs = new int[] { 1, 1, 2 };

            var answer = LC26.LC26.RemoveDuplicates(strs);
            Console.Write(answer);
        }
    }
}
