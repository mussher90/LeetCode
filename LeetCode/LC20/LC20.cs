using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LC20
{
    public static class LC20
    {
        public static bool IsValid(string parentheses)
        {
            bool valid;
            do
            {
                var length = parentheses.Length;

                parentheses = parentheses.Replace("()", "");
                parentheses = parentheses.Replace("{}", "");
                parentheses = parentheses.Replace("[]", "");

                valid = parentheses.Length < length;

                if(parentheses == "")
                {
                    return true;
                }

            } while (valid);

            return false;
        }
    }
}
