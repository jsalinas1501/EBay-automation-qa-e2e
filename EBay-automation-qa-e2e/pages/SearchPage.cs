using EBay_automation_qa_e2e.entities;
using EBay_automation_qa_e2e.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBay_automation_qa_e2e.pages
{
    
    public class SearchPage
    {
        // VARIABLES
        static Utils util = new Utils();
        public static List<Product> products = new List<Product>();

        // ELEMENTS
        private IWebDriver _driver;

        By result                       = By.Id("srp-river-results");
        By brands                       = By.XPath("//div[@id='x-refine__group_1__0']//span[1]");
        By sizes                        = By.XPath("//div[@id='x-refine__group_1__3']//span[1]");
        By numberofResults              = By.XPath("//h1[@class='srp-controls__count-heading']/span[1]");
        By orderOptionsButton           = By.Id("w9");
        By orderByPriceAscendantButton  = By.XPath("//*[@class='srp-sort__menu']/li[4]");

        // CONSTRUCTOR
        public SearchPage(IWebDriver _driver) => this._driver = _driver;

        // ACTIONS
        public void waitForResults()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(result));
        }

        public void selectBrand(String brand)
        {
            ICollection<IWebElement> elements = _driver.FindElements(brands);

            foreach (IWebElement element in elements)
            {
                if (element.Text.ToLower().Trim().Equals(brand))
                {
                    element.Click();
                    return;
                }
            }
        }

        public void selectSize(String size)
        {

            waitForResults();
            ICollection<IWebElement> elements = _driver.FindElements(sizes);

            foreach (IWebElement element in elements)
            {
                if (element.Text.ToLower().Trim().Equals(size))
                {
                    element.Click();
                    waitForResults();
                    util.PrintResults("1. Printing the number of results\n");
                    util.PrintResults(_driver.FindElement(numberofResults).Text);
                    return;
                }
            }
        }

        public void orderByPriceAscendant()
        {
            waitForResults();

            Actions builder = new Actions(_driver);
            builder.MoveToElement(_driver.FindElement(orderOptionsButton)).Perform();

            _driver.FindElement(orderByPriceAscendantButton).Click();

            waitForResults();

            products = getProductsFromList(5);

            util.PrintResults("\n2. Printing the first 5 results\n");
            util.PrintProducts(products);
        }

        public List<Product> getProducts()
        {
            return products;
        }

        List<Product> getProductsFromList(int val)
        {
            string itemcontainer = "";
            List<Product> listproduct = new List<Product>();
            Product product = new Product();

            for(int i=0; i<val; i++)
            {
                product = new Product();
                itemcontainer = "//*[@id=\"srp-river-results-listing" + (i + 1) + "\"]";
                product.SetTitle(_driver.FindElement(By.XPath(itemcontainer+ "//*[@class='s-item__title']")).Text);
                product.SetPrice(_driver.FindElement(By.XPath(itemcontainer+ "//*[@class='s-item__price']")).Text);
                listproduct.Add(product);
            }

            return listproduct;
        }

        public void orderByNameAscendant()
        {
            products.Sort(new Comparer());
            util.PrintResults("\n3. Printing the first 5 results orderded by name\n");
            util.PrintProducts(products);
        }

        public void orderByPriceDescendant()
        {
            products.Sort(new DoubleComparer());
            util.PrintResults("\n4. Printing the first 5 results orderded by price descendant\n");
            util.PrintProducts(products);
        }




    }
}
