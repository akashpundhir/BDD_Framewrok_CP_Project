Feature: 3_OrderAProduct
	As a user I want to check if I can order a product

Background: 
	Given Edge browser is started
	And Charter site is opened

@regression @smoke
Scenario: Order as incognito - Check Login modal
	Given I am on a "Brava" product page
	And I selected standard "Brava" pack
	And I pressed Add to basket
	Then Login to your account modal is shown

@regression @smoke
Scenario: Order a sample
	Given I logged in "without" cutting template
	And Basket is empty
	And I am on a "Adhesive" product page
	And I selected sample
	And I pressed Add to basket
	When I go to checkout
	And I submit order request
	Then Success screen is shown

@regression @smoke
Scenario: Order a product
	Given I logged in "without" cutting template
	And Basket is empty
	And I am on a "SenSura" product page
	And I selected standard "SenSura" pack
	And I selected quantity
	And I pressed Add to basket
	When I go to checkout
	Then I see Complimentary item page
	When I "do not add" complimentary item
	And I submit order request
	Then Success screen is shown

@regression
Scenario: Reorder your products
	Given I logged in "without" cutting template
	And Basket is empty
	And I am on My Account page
	And I have Order Template set up in SF
	When I add my product to basket
	And I go to checkout
	#And I do not add complimentary item
	And I submit order request
	Then Success screen is shown

@regression
Scenario: Check IC product card
	Given I selected product category
	Then Info about product is shown on product card

@regression
Scenario: Check IC product page
	Given I selected a product
	Then Info about product is shown on product page

@regression
Scenario: Order with complimentary items
	Given I added "my" products to basket
	Then I see Complimentary item page
	When I "add" complimentary item
	Then I can see complimentary items are added
	When I submit order request
	Then Success screen is shown


# commented out due to instability - even though reason for change is set up for "this order only" 
##
#@regression
#Scenario: Check if user remove from basked a product complimentary items should be also removed
#	Given I logged in "without" cutting template
#	And Basket is empty
#	And I am on My Account page
#	And I have Order Template set up in SF
#	When I add my products and complimentary to basket
#	And I confirm quantity
#	Then I can see product and complimentary item added to the basket
#	When I remove product from basket
#	Then All items are removed from basket

# commented out due to instability - even though reason for change is set up for "this order only" 
# it's added to order template and require a manual deletion
#
#@regression
#Scenario: Order a different product than in Order Template (change reason page)
#	Given I added Brava products to basket
#	Then I see Change reason page
#	When I click Save and continue
#	Then Error popup is displayed
#	When I tick a reason for change
#	And I click Save and continue
#	Then I see Complimentary item page
#	When I do not add complimentary item
#	And I submit order request
#	Then Success screen is shown