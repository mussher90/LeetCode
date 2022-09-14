using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.LC13
{
    public static class RNCalculator
    {
        public static List<string> ConvertToArray(string romanNumeral)
        {

            var newArray = romanNumeral.ToCharArray().Select(x => x.ToString()).Reverse().ToList();

            return newArray;
        }

        public static List<RNEnum> ConvertToEnumArray(List<string> stringArray)
        {
            var enumEnum = new List<RNEnum>();

            foreach(string x in stringArray)
            {
                enumEnum.Add((RNEnum)Enum.Parse(typeof(RNEnum), x));
            }

            return enumEnum;
        }

        public static int CalculateIntegerRepresentation(List<RNEnum> enumList)
        {
            int answer = 0;

            while(enumList.Count > 1)
            {
                var head = enumList[0];
                int term;
                if (head > enumList[1])
                {
                    term = (int)head - (int)enumList[1];
                }
                else
                {
                    term = (int)enumList[1] + (int)head;
                }

                answer += term;
                enumList.RemoveRange(0, 2);
            }

            if(enumList.Count == 1)
            {
                answer += (int)enumList[0];
            }

            return answer;
        }

        public static int Calculate(string RomanNumeral)
        {
            List<string> RomanNumeralArray = ConvertToArray(RomanNumeral);
            var RomanNumeralEnumArray = ConvertToEnumArray(RomanNumeralArray);
            var answer = CalculateIntegerRepresentation(RomanNumeralEnumArray);

            return answer;
        }
    }
}
