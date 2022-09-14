using System;
using System.Linq;


namespace LeetCode.LC42
{
    public class RainWater2
    {
        //strategty : take an element, find the first element with a greater or equal value than it
        //fill all the intervening elements with the first elements value "flood" them.
        //Repeat for the next element.  If no greater element exists, reverse the array and repeat step one.

        public static int Trap(int[] height)
        {
            var length = height.Length;
            var filledHeight = new int[length];
            var maxElem = height.Max();
            var end = 0;

            FillMax(maxElem, ref filledHeight, height, false, null, ref end);

            var i = 0;
            while(i < length)
            {
                
                filledHeight[i] = height[i];

                var j = i+1;

                while (j < length && height[j] <= height[i])
                {
                    filledHeight[j] = height[i];

                    j++;
                }
                i=j;

                if (height[i] == maxElem)
                {
                    filledHeight[i] = height[i];
                    i++;
                }
            }
            return FilledHeight(filledHeight, height);
        }

        private static int FilledHeight(int[] filledHeight, int[] height)
        {
            var total = 0;

            var length = height.Length;

            for (var i = 0; i < length; i++)
            {
                total += (filledHeight[i] - height[i]);
            }
            return total;
        }

        private static void FillMax(int maxValue, ref int[] filledHeight, int[] height, bool reversed, int? index, ref int end)
        {
            var start = index ?? Array.FindIndex(height, x => x == maxValue);
            end = reversed ? Array.FindIndex(height, x => x > maxValue) : Array.FindLastIndex(height, x => x >= maxValue);

            if (end == -1) {
                filledHeight[start] = height[start];
                return;
            }

            if (start == end || start + 1 == end)
            {
                filledHeight[start] = height[start]; 
            }
            else
            {
                Array.Fill(filledHeight, maxValue, start, end - start + 1);
            }
        }

        //strategy : take and element, find the last element greater than or equal to it and flood all the intervening elements
        //jump to the next element greater than the current one and repeat
        public static int Fill(int[] height)
        {
            var length = height.Length;
            var filledHeight = new int[length];

            var i = 0;
            var reversed = false;

            if (!DoesItContainAWell(height)) return 0;

            while (i < length)
            {
                var end = 0;
                var value = height[i];
                FillMax(value, ref filledHeight, height, reversed, i, ref end);
                i = reversed ? end : Array.FindIndex(height, x => x > value);

                if (i == -1 && !reversed) { 
                    height = height.Reverse().ToArray();
                    filledHeight = filledHeight.Reverse().ToArray();
                    i = 0;
                    reversed = true;
                }
                else if (i == -1) { break; }
            }

            return FilledHeight(filledHeight, height);
        }

        public static bool DoesItContainAWell(int[] height)
        {
            var dip = false;
            var length = height.Length - 1;

            for(var i = 1; i < length; i++)
            {
                var a = height[i + 1] > height[i];
                var b = height[i - 1] > height[i];

                if (b)
                {
                    dip = true;
                }

                if(a && dip)
                {
                    return true;
                }
            }

            return false ;
        }
    }
}
