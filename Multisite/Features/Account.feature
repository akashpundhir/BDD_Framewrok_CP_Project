Feature: 4_Account
	My Account tests

Background: 
	Given Edge browser is started
	And Multisite site is opened

#@smoke @regression @newaccount
#Scenario: Check that NDIS funding is saved correctly
#	Given B2C account is created
#	And I ordered a product with NDIA-managed funding
#	Then I click Account
#	And Funding info is correctly saved
#
#@smoke @regression @newaccount
#Scenario: Check that delivery info is saved during Order flow
#	Given B2C account is created
#	And I opened main page
#	And I selected a product
#	And I selected Standard pack
#	And I pressed Add to basket
#	When I go to checkout
#	And I proceed to payment
#	And I accept consent
#	And I press continue to payment
#	And I pay with selected card
#	Then Success screen is shown
#	And I click Account
#	And Profile is saved
#
#@smoke @regression @newaccount
#Scenario: Check that product is saved to My Products
#	Given B2C account is created
#	And I opened main page
#	And I selected a product
#	And I selected Standard pack
#	And I pressed Add to basket
#	When I go to checkout
#	And I proceed to payment
#	And I accept consent
#	And I press continue to payment
#	And I pay with selected card
#	Then Success screen is shown
#	And I click Account
#	And Ordered product is shown on Profile page

#@regression @newaccount
#Scenario: Edit Funding information - NDIS number
#	Given B2C account is created
#	And I ordered a product with NDIA-managed funding
#	Then I click Account
#	And I change NDIS number
#	And Funding info is correctly saved