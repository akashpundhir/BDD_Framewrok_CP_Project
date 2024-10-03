Feature: 3_OrderAProduct
	As a user I want to check if I can order a product
Background:
	Given Edge browser is started
	And Multisite site is opened
@regression
Scenario: Order as incognito - Check Login modal
	Given I selected a product
	And I selected Standard pack
	And I pressed Add to basket
	When I go to checkout
	Then Login to your account modal is shown
@smoke @regression
Scenario: Order IC product - self pay
	Given I logged in
	And Basket is empty
	And I opened main page
	And I selected a product
	And I selected Standard pack
	And I pressed Add to basket
	When I go to checkout
	Then I see Complimentary item page
	When I "do not add" complimentary item
	Then Funding update from NDIS to own funding
	And I proceed to payment
	#And I press continue to payment
	And I pay with selected card
	Then Success screen is shown
	#And Order number equals to order number on Profile page
@smoke @regression
Scenario: Order IC product - NDIS pay
	Given I logged in
	And Basket is empty
	And I opened main page
	And I selected a product
	And I selected Standard pack
	And I pressed Add to basket
	When I go to checkout
	Then I see Complimentary item page
	When I "do not add" complimentary item
	Then I edit the payment details and fill NDIS payment details
	And I continue with order
	Then Success screen is shown
@regression
Scenario: Check IC product card
	Given I selected product category
	Then Info about product is shown on product card
@regression
Scenario: Check IC product page
	Given I selected a product
	Then Info about product is shown on product page
#@smoke @regression
#Scenario: Check that credit card is saved during Order flow
#	Given I logged in
#	And Basket is empty
#	And I opened main page
#	And I selected a product
#	And I selected Standard pack
#	And I pressed Add to basket
#	When I go to checkout
#	Then I see Complimentary item page
#	When I do not add complimentary item
#	And I proceed to payment
#	And I pay with selected card
#	Then Success screen is shown
#	Given I opened main page
#	And I selected a product
#	And I selected Standard pack
#	And I pressed Add to basket
#	When I go to checkout
#	And I proceed to payment
#	And I press continue to payment
#	Then I see saved credit card
#@regression
#Scenario: Order IC product - NDIS - NDIA managed
#	Given B2C account is created
#	And Basket is empty
#	And I opened main page
#	And I selected a product
#	And I selected Standard pack
#	And I pressed Add to basket
#	When I go to checkout
#	Then I see Complimentary item page
#	When I do not add complimentary item
#	#address
#	And I select NDIS
#	And I proceed to payment
#	And I select NDIA-managed
#	And I fill NDIS participant number
#	And I press continue to summary
#	And I accept consent
#	And I press continue to payment
#	Then Success screen is shown
#	And Order number equals to order number on Profile page
#
#@regression
#Scenario: Order IC product - NDIS - Self managed
#	Given I logged in
#	And Basket is empty
#	And I opened main page
#	And I selected a product
#	And I selected Standard pack
#	And I pressed Add to basket
#	When I go to checkout
#	Then I see Complimentary item page
#	When I do not add complimentary item
#	And I select NDIS
#	And I proceed to payment
#	And I select self-managed
#	And I fill NDIS participant number
#	And I press continue to summary
#	And I accept consent
#	And I press continue to payment
#	And I pay with selected card
#	Then Success screen is shown
#	And Order number equals to order number on Profile page
#
#@smoke @regression 
#Scenario: Order IC product - NDIS - Plan managed
#	Given I logged in
#	And Basket is empty
#	And I opened main page
#	And I selected a product
#	And I selected Standard pack
#	And I pressed Add to basket
#	When I go to checkout
#	Then I see Complimentary item page
#	When I do not add complimentary item
#	And I select NDIS
#	And I proceed to payment
#	And I select plan-managed
#	And I fill NDIS participant number
#	And I fill plan company data
#	And I press continue to summary
#	And I accept consent
#	And I press continue to payment
#	Then Success screen is shown
#	And Order number equals to order number on Profile page
@regression
#Scenario: Reorder item from MyAccount page
#	Given Multisite site is opened
#	Given I logged in
#	And Basket is empty
#	And Basket is empty
#	Then I navigate to My account page
#	Then I pressed Add to basket
#	When I go to checkout
#	And I proceed to payment
#	And I pay with selected card
#	Then Success screen is shown
#	And Order number equals to order number on Profile page
@regression
Scenario: Delivery is not free while reordering
	Given South Africa Multisite site is opened
	Given I logged to SF site
	And Basket is empty
	Then I navigate to My account page and add items to basket
	Then Flyoutbasket displayed with Delivery charges
	And Delivery charges displayed on flyoutbasket
	And Delivery charges successfuly verified on flyoutbasket
	Then I emptied the basket and test case successfuly completed
@regression
Scenario: Update delivery details from Order Summary page
	Given Multisite site is opened
	Given I logged in
	And Basket is empty
	Then I navigate to My account page
	Then I pressed Add to basket
	When I go to checkout
	Then I edit my first name and last name in delivery address
	And address update successfuly
@regression
Scenario: Update payment details from Order Summary page
	Given Multisite site is opened
	And I logged in
	Then I navigate to My account page
	Then I pressed Add to basket
	When I go to checkout
	Then I edit the payment details and fill NDIS payment details
	And payment details update successfully
	Then I navigate to My account page
@regression @smoke
Scenario: User is redirected to delivery information page with sample added to the basket
	Given SignUp flow is started
	When I enter new email
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click Create account button
	Then New account is created
	When I opened main page
	And I selected a product
	And I selected sample
	And I pressed Add to basket
	When I go to checkout
	Then I am on the Delivery Information page
	When I fill delivery info deatils 
	And I accept consent and save
	When I accept marketing permission 
	And Order sample
	Then Success screen is shown
@Smoke
Scenario: Sample as incognito - Registration after adding sample to basket
	Given I selected a sample
	And I selected sample
	And I pressed Add to basket
	And I choose I am a customer
	When I go to checkout
	Then Login to your account modal is shown
	When I press register button
	Then  start SignUp flow
	When I enter new email
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click Create account button
	Then New account is created
	When I click continue adding products
	Then I am on the Delivery Information page
	When I fill delivery info deatils
	And I accept consent and save
	When I accept marketing permission 
	And Order sample
	Then Success screen is shown
@regression @smoke
Scenario: Products on minishop are clickable
	Given Multisite site is opened
	And I'm on the minishop page
	When I click on a product
	Then I'm on the product page
@regression @smoke
Scenario: Sample is added to old fly out basket (healthcare proffessional)
	Given Multisite site is opened
	And I selected sample
	And I pressed Add to basket
	Then I can see consent modal
	When I choose healthcare proffessional option
	Then I'm redirected to the old basket page
	When I fulfill hcp delivery info and submit
	Then I see old success screen
@regression
Scenario: Pay by SEPA while reordering
	Given South German Multisite site is opened
	Then I logged to DE site
	Then Continue checkout
	When I select SEPA pay on Payment page
	Then I order successfully
@regression
Scenario: Checkout as guest with Sample order - I am consumer
	Given Multisite site is opened
	Then I navigate to speedicath-flex smaple product page
	Then I added a smaple to the basket and hit order free sample button
	Then Pop modal displayed
	Then I selected Procced without registration on Login modal
	Then filled the dteails on dleivery infomartion page
	Then completed sampling consnet permisision
	Then comleted Marketing permisision
	And order summary page veryfied delivery details and click on continure button
	Then Sample order placed successfuly and I am navigated to order confrimation page
@regression
Scenario: Checkout as guest - out of pocket
	Given Multisite site is opened
	Then I navigate to speedicath flex set  product page
	Then I added a item to the basket and hit continue
	Then Click Checkout CTA on flyout basket
	Then Click Proceed without registration link
	And Entered all delivery information
	Then Accpeted Order Consent and  marketing permission
	Then Click Proceed to payment CTA on summary page
	When I entered the card details and click payment
	Then OOP order successfully placed without user registration
@regression
Scenario: Tax is free and not free on delivery address according Spain postal codes
	Given Spain Multisite site is opened
	Then I logged in on Spain website
	Given Basket is empty
	Then I navigate to My Account page on Spain
	Then Flyoutbasket displayed with TAX charges
	Then I continued to deliveryinfo page and entered address details
	Then I navigate to order summary page and verified Tax amount for the order
	And Completed tax is free  Order of Valleseco city in Las Palmas Province