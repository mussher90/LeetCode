using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LC13
{
    public static class RNCalc2
    {
        private static Dictionary<Char, int> RomanNumerals = new Dictionary<char, int> {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000}
        };

        public static int CalculateNumber(string romanNumeral)
        {
            var number = 0;
            Char prev = '0';
            var reverseRN = romanNumeral.Reverse();

            foreach(char x in reverseRN)
            {
                var current = RomanNumerals[x];
                if(prev == '0')
                {
                    number += RomanNumerals[x];
                }
                else if(current < RomanNumerals[prev])
                {
                    number -= current;
                }
                else
                {
                    number += current;
                }

                prev = x;
            }

            return number;
        }
    }
}
