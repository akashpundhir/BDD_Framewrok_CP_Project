Feature: 4_CuttingService

	As a user I want to check if I can order a product with cutting service

Background: 
	Given Edge browser is started
	And Charter site is opened

@regression
Scenario: Order with cutting service (no template in SF)
	Given I logged in "without" cutting template
	And Basket is empty
	And I am on a "SenSura" product page
	And I selected standard "SenSura" pack
	And I selected quantity
	And I ticked I want cutting service
	And I pressed Add to basket
	Then I see cutting service checkbox ticked and cutting service banner displayed "cutting template doesn't exist"
	When I go to checkout
	Then I see Complimentary item page
	And I see cutting template is added
	When I "do not add" complimentary item
	Then I see order summary page
	And Cutting service is added to the order
	When I submit order request
	Then Success screen is shown

@regression
Scenario: Order with cutting service (template added in SF)
	Given I logged in "with" cutting template
	And Basket is empty
	And I am on a "SenSura" product page
	And I selected standard "SenSura" pack
	And I selected quantity
	And I pressed Add to basket
	Then I see cutting service checkbox ticked and cutting service banner displayed "cutting template added in SF"
	When I go to checkout
	Then I see Complimentary item page
	And I see cutting template is added
	When I "do not add" complimentary item
	Then I see order summary page
	And Cutting service is added to the order
	When I submit order request
	Then Success screen is shown