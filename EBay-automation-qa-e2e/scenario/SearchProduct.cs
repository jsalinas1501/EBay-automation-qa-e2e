using System;
using EBay_automation_qa_e2e.steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace EBay_automation_qa_e2e.scenario
{
    [TestClass]
    public class SearchProduct
    {
        [TestMethod]
        public void SearchAndOrderProducts()
        {
            SearchProductSteps.GivenIHaveNavigatedToTheEBayPage("https://www.ebay.com/");
            SearchProductSteps.WhenISearchTheProduct("shoes");
            SearchProductSteps.WhenISelectTheBrand("puma");
            SearchProductSteps.WhenISelectTheSize("10");
            SearchProductSteps.WhenIOrderTheResultsByPrice("ascendant");
            SearchProductSteps.ThenTheFirstFiveProductsAreTheExpected();
            SearchProductSteps.WhenIOrderTheResultsByName("ascendant");
            SearchProductSteps.WhenIOrderTheResultsByPrice("descendant");
            SearchProductSteps.ThenTheFirstProductPrintedIs("Puma Adultos Unisex POPCAT Verano Playa Deportes Correa Diapositiva Sandalias Zapatos Blanco..");
            SearchProductSteps.TearDown();
        }

        [TearDown]
        public void Teardown()
        {
            SearchProductSteps.TearDown();
        }

    }
}
