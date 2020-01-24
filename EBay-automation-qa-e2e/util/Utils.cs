using EBay_automation_qa_e2e.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBay_automation_qa_e2e.util
{
    public class Utils
    {
        public void PrintResults(string val)
        {
            Console.WriteLine(val);
        }

        internal void PrintProducts(List<Product> products)
        {
            foreach(Product element in products)
            {
                PrintResults(element.GetTitle());
                PrintResults(element.GetPrice());
            }
        }
    }
}
