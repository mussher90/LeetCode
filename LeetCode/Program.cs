using LeetCode.LC13;
using LeetCode.LC42;
using System;
using System.Diagnostics;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var strs = new int[] { 1, 1 };

            var answer = LC11.LC11.MaxArea(strs);
            Console.Write(answer);
        }
    }
}
