Feature: 1_Basic
As user I want to check that Multisite is opened and I can login
Background: 
	Given Edge browser is started
	And Multisite site is opened
@smoke @regression
Scenario: Check multisite opened
	Then Main page is opened
@smoke @regression
Scenario: Login to Multisite
	When I press login button
	And I enter email
	And I enter password
	And I press log in button
	Then I successfully logged in
@regression
Scenario: Navigate Delivery Info Page to update multiple address
	Given Multisite site is opened
	And Multisite site is opened
	When I press login button
	And I enter email
	And I enter password
	And I press log in button
	Then I successfully logged in
	Given Basket is empty
	Then the user Update primary address details
	And the user Add alternative address details
	And the user Update alternative address
	And the user Add Last alternative address details
	And the user Delete alternative address
	Then the changes are saved and page deliveryinfo page refresh
