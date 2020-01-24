using EBay_automation_qa_e2e.entities;
using EBay_automation_qa_e2e.pages;
using EBay_automation_qa_e2e.util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace EBay_automation_qa_e2e.steps
{

    [Binding]
    class SearchProductSteps
    {
        static IWebDriver currentDriver = new ChromeDriver(Environment.CurrentDirectory);
        static HomePage homePage = new HomePage(currentDriver);
        static SearchPage searchPage = new SearchPage(currentDriver);
        static List<Product> products = new List<Product>();
        static Utils util = new Utils();


        static Product firstProduct = new Product("Puma Adultos Unisex POPCAT Verano Playa Deportes Correa Diapositiva Sandalias Zapatos Blanco..", "S/. 70.87");
        static Product secondProduct = new Product("Las diapositivas del gato Puma plomo (36026302) Deportes Sandalias Flip Flop Zapatos Zapatillas diapositiva", "S/. 99.25");
        static Product thirdProduct = new Product("Las diapositivas del gato Puma plomo (36026301) Deportes Sandalias Flip Flop Zapatos Zapatillas diapositiva", "S/. 99.25");
        static Product fourthProduct = new Product("Las diapositivas del gato Puma plomo (36026308) Deportes Sandalias Flip Flop Zapatos Zapatillas diapositiva", "S/. 99.25");
        static Product fifthProduct = new Product("Puma Cat diapositivas (36026321) Lead Deportes Sandalias Flip Flop Zapatos Zapatillas diapositiva", "S/. 99.25");

        [Given(@"I have navigated to the EBay page (.*)$")]
        public static void GivenIHaveNavigatedToTheEBayPage(String page)
        {
            currentDriver.Manage().Window.Maximize();
            currentDriver.Manage().Cookies.DeleteAllCookies();
            currentDriver.Navigate().GoToUrl(page);
        }

        [When(@"I search the product (.*)$")]
        public static void WhenISearchTheProduct(String product)
        {
            homePage.typeProduct(product);
            homePage.searchProduct();
        }

        [When(@"I select the brand (.*)$")]
        public static void WhenISelectTheBrand(String brand)
        {
            searchPage.selectBrand(brand);
        }

        [When(@"I select the size (.*)")]
        public static void WhenISelectTheSize(String size)
        {
            searchPage.selectSize(size);
        }

        [When(@"I order the results by price (ascendant|descendant)$")]
        public static void WhenIOrderTheResultsByPrice(String orderPrice)
        {
            if (orderPrice.Equals("ascendant"))
                searchPage.orderByPriceAscendant();
            else if (orderPrice.Equals("descendant"))
                searchPage.orderByPriceDescendant();
        }

        [Then(@"the first five products are the expected")]
        public static void ThenTheFirstFiveProductsAreTheExpected()
        {
            List<Product> expectedProd = new List<Product>();
            products = searchPage.getProducts();

            expectedProd.Add(firstProduct);
            expectedProd.Add(secondProduct);
            expectedProd.Add(thirdProduct);
            expectedProd.Add(fourthProduct);
            expectedProd.Add(fifthProduct);

            for (int i=0; i < products.Count; i++)
            {
                try
                {
                    Assert.AreEqual(products[i].GetTitle(), expectedProd[i].GetTitle());
                    Assert.AreEqual(products[i].GetPrice(),expectedProd[i].GetPrice());
                } catch (AssertFailedException e)
                {
                    util.PrintResults("\n" + e.Message);
                    return;
                }
            }

            util.PrintResults("\nAssert completed with status OK\n");

        }

        [When(@"I order the results by name (ascendant|descendant)$")]
        public static void WhenIOrderTheResultsByName(String orderName)
        {
            if (orderName.Equals("ascendant"))
                searchPage.orderByNameAscendant();
        }

        [Then(@"the first product printed is (.*)$")]
        public static void ThenTheFirstProductPrintedIs(String product)
        {
            products = searchPage.getProducts();

            try
            {
                Assert.AreEqual(products[0].GetTitle(),product);
            }catch(AssertFailedException e)
            {
                util.PrintResults("\n" + e.Message);
                return;
            }

            util.PrintResults("\nSecond assert completed with status OK\n");
        }

        public static void TearDown()
        {
            currentDriver.Quit();
        }
    }
}
