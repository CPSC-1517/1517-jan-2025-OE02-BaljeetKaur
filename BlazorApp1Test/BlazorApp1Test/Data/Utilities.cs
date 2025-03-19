using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReviewJan14
{
    static class Utilities
    {
        public static bool IsZeroOrPositive(double value)
        {
            bool valid = true;
            if (value < 0.0)
            {
                valid = false;
            }
            return valid;
        }

        public static bool IsZeroOrPositive(int value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }

        public static bool IsZeroOrPositive(decimal value)
        {
            bool valid = true;
            if (value < 0.0m)
            {
                valid = false;
            }
            return valid;
        }




    }
}
