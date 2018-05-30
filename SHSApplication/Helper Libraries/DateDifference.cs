using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Helper_Libraries
{
    public static class DateDifference
    {
        public static int GetMonthDifference(DateTime start,DateTime end)
        {
            int m1;
            int m2;
            if (start<end)
            {
                m1 = (end.Month - start.Month);
                m2 = (end.Year - start.Year);
            }
            else
            {
                m1 = (start.Month - end.Month);
                m2 = (start.Year - end.Year);
            }

            return m1 + m2;
        }
    }
}
