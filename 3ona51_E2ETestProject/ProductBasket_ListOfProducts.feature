Feature: List of products in productBasket
	In order to simplify shoping
	As a customer
	I want to see products in my productBasket

@mytag
Scenario: Add products to the productBasket
	Given I have opened the store page
	And I have choosen a product
	And I have pressed the buyProductButton  
	When I go to the productBasket
	Then I see the product added to it

Scenario: A choosen product has already added to the productBasket
	Given I have added a product to the productBasket  
	When I find the same product on the store page
	Then I see the buyProductButton was changed on alreadyInBasketButton


Scenario: Delete a product from the productBasket
	Given I have added a product to the productBasket
	And I have opened the productBaket  
	When I press deleteProductFromBasket
	Then the product is removed from the productBasket


