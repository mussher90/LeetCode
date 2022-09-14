using System;
using System.Text.RegularExpressions;

namespace LeetCode.LC14
{
    public static class LongestPrefix
    {
        public static string Prefix(string[] strings)
        {
            var common = "";

            var start = strings[0];

            bool commonPrefix = false;

            var i = 0;

            Regex regex;

            string[] matches;

            if (start.Length == 0) return common;

            do
            {
                regex = new Regex($"^({start[0..(i + 1)]})\\w*");

                matches = Array.FindAll(strings, x => regex.IsMatch(x));

                commonPrefix = matches.Length == strings.Length;


                if (commonPrefix)
                {
                    common += start[i];
                    i++;
                }

                if (common == start) break;


            } while (commonPrefix);

            return common;
        }
    }
}
