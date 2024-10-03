Feature: OrderAProduct

As a user I want to check if I can order a product

Background: 
	Given Edge browser is started
	And Lilial site is opened

@smoke
Scenario: Checkout as guest - out of pocket
	Given I navigate to speedicath flex set  product page
	Then I added a item to the basket and hit continue
	Then Click Checkout CTA on flyout basket
	Then I select the signup on modal
	Then start SignUp flow
	When I enter new email
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click Create account button
	Then account is created and Modal displayed
