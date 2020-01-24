Feature: EbaySearch
	As a EBay user
	I want to search a product in the page
	So that I can find the products I want

@reggression
@Browser: Chrome
Scenario: Search Product, filter by brand and size and order it by certains criteria
	Given I have navigated to the EBay page https://www.ebay.com/
	When I search the product shoes
	And I select the brand puma
	And I select the size 10
	And I order the results by price ascendant
	Then the first five products are the expected
	When I order the results by name ascendant
	And I order the results by price descendant
	Then the first product printed is Puma Cat diapositivas (36026321) Lead Deportes Sandalias Flip Flop Zapatos Zapatillas diapositiva