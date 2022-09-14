using System;
using System.Collections.Generic;

namespace LeetCode.LC1
{
    public static class TwoSum
    {
        public static int[] FirstAttempt(int[] nums, int target)
        {
            for(var i = 0; i < nums.Length; i++)
            {
                var leftOver = target - nums[i];

                var index = Array.FindLastIndex(nums, x => x == leftOver);

                if(index != -1 && index != i)
               {
                    var index1 = Array.FindIndex(nums, x => x == nums[i]);

                    return new int[] { index1, index };
                }
            }

            return new int[] { 0, 0 };
        }

        //faster
        public static int[] SecondAttempt(int[] nums, int target)
        {
            var length = nums.Length;

            for(var i = 0; i < length - 1; i++)
            {
                for(var j = i+1; j < length; j++)
                {
                    if(nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { 0, 0 };
        }

        //fastest
        public static int[] ThirdAttempt(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                map.TryAdd(nums[i], i);
            }

            return new int[] { 0, 0 };
        }
    }
}
