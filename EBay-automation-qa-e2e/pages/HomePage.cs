using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBay_automation_qa_e2e.pages
{
    public class HomePage
    {
        // ELEMENTS
        private IWebDriver _driver;
        By searchBar    = By.Id("gh-ac");
        By searchButton = By.Id("gh-btn");

        public HomePage(IWebDriver _driver) => this._driver = _driver;

        //ACTIONS
        public void typeProduct(String product)
        {
            _driver.FindElement(searchBar).SendKeys(product);
        }

        public void searchProduct()
        {
            _driver.FindElement(searchButton).Click();
        }
    }
}
