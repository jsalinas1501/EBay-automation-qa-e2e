using EBay_automation_qa_e2e.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBay_automation_qa_e2e.util
{
    class Comparer : IComparer<Object>
    {
        public int Compare(object x, object y)
        {
            return (((Product)x).GetTitle()).CompareTo(((Product)y).GetTitle());
        }
    }

    class DoubleComparer : IComparer<Object>
    {
        public int Compare(object x, object y)
        {
            return Convert.ToInt32(double.Parse((((Product)x).GetPrice().Replace("S/.", "").Substring(0, 6)).Trim()) -
                (double.Parse((((Product)y).GetPrice().Replace("S/.", "").Substring(0, 6)).Trim())));
        }
    }
}
