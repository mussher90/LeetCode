using System;
using System.Linq;

namespace LeetCode.LC42
{
    public static class RainWater
    {
        public static int[] ReduceList(int[] height)
        {
            var firstNonZero = Array.FindIndex(height, x => x > 0);
            var lastNonZero = Array.FindLastIndex(height, x => x > 0) + 1;

            if (firstNonZero == -1) return Array.Empty<int>();

            return height[firstNonZero..lastNonZero];
        }

        public static int CountZeros(int[] heightList)
        {
            return Array.FindAll(heightList, x => x == 0).Length;
        }

        public static int[] LowerHeight(int[] heightList, int val)
        {

            if (val == 0) return heightList;

            for(var i = 0; i < heightList.Length; i++)
            {
                heightList[i] = ReduceLevel(heightList[i], val);
            }

            return heightList;
        }

        public static int CalculateRainWater(int[] height)
        {
            if (height.Length <= 1) return 0;

            height = ReduceList(height);

            height = PrepArray(height);

            int rainWater = InitialZeros(ref height);

            while (height.Length > 1)
            {
                rainWater += CountZeros(height);
                height = LowerHeight(height, 1);
                height = ReduceList(height);
            }

            return rainWater;
        }

        public static int ReduceLevel(int x, int val)
        {
            return x > 0 ? x - val : x;
        }

        public static int[] PrepArray(int[] height)
        {
            var originalLength = 0;

            while(height.Length != originalLength)
            {
                originalLength = height.Length;

                var min = height.Min();

                height = ReduceList(LowerHeight(height, min));

            }

            return height;
        }

        public static int InitialZeros(ref int[] height)
        {
            var nonZeros = Array.FindAll(height, x => x > 0);

            var minNonZero = nonZeros.Min();

            var zeros = height.Length - nonZeros.Length;

            height = ReduceList(LowerHeight(height, minNonZero));

            return zeros*minNonZero;
        }
    }
}

