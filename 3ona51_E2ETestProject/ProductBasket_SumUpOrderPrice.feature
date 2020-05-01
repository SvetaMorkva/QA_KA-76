Feature: ProductBasket_SumUpOrderPrice
	In order to simplify shopping
	As a customer
	I want to see the summarized order price

@mytag
Scenario: Add price of added to the productBasket product to SumUpOrderPrice 
	Given I have added a product to productBasket
	When I go to the productBasket
	Then I see the SumUpOrderPrice of all added products

Scenario: Subtract price of deleted from the productBasket product from SumUpOrderPrice 
	Given I have deleted a product from productBasket
	When I go to the productBasket
	Then I see the SumUpOrderPrice of remaining products