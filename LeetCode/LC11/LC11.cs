using System;

namespace LeetCode.LC11
{
    public static class LC11
    {
        public static int MaxArea(int[] height)
        {
            var max = 0;

            var length = height.Length;

            var reversed = false;

            for(var i = 0; i < length;)
            {
                var j = Array.FindLastIndex(height, y => y >= height[i]);
                var area = height[i] * (Math.Abs(i - j));

                max = area > max ? area : max;

                i = Array.FindIndex(height, y=> y> height[i]);

                if (i == -1) {
                    if (reversed) break;

                    Array.Reverse(height);

                    reversed = true;

                    i = 0;
                }
            }

            return max;
        }
    }
}
