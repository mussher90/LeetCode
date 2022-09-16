using System;
using System.Linq;

namespace LeetCode.LC26
{
    public static class LC26
    {
        public static int RemoveDuplicates(int[] list)
        {
            var length = list.Length;

            var max = list.Max();

            for(var i = 0; i < length - 1; i++)
            {

                if (list[i] == list[i + 1])
                {
                    list[i] = max + 1;
                }
            }

            Array.Sort(list);

            return Array.FindLastIndex(list, x => x == max) + 1;
        }
    }
}
