using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBay_automation_qa_e2e.entities
{
    public class Product
    {
        private String title;
        private String price;

        public Product()
        {

        }

        public Product(String title, String price)
        {
            this.title = title;
            this.price = price;
        }

        public String GetTitle()
        {
            return title;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public String GetPrice()
        {
            return price;
        }

        public void SetPrice(string price)
        {
            this.price = price;
        }
    }
}
