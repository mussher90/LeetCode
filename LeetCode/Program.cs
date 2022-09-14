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
            var strs = new string[] { "" };

            var answer = LC14.LongestPrefix.Prefix(strs);
            Console.Write(answer);
        }
    }
}
