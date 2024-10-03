Feature: 1_Basic
As user I want to check that Charter is opened and I can login

Background: 
	Given Edge browser is started
	And Charter site is opened

@smoke @regression
Scenario: Check Charter opened
	Then Main page is opened

@regression
Scenario: Search for a product
	When I search for a product
	Then Page of "SenSura" I searched is open

@regression
Scenario: Search for article
	When I search for an article
	Then I can see articles in search results
	And I can open article by clicing on it
	And I see article page open

@smoke @regression
Scenario: Login to Charter
	When I press login button
	And I enter email for account "without" cutting template
	And I enter password
	And I press log in button
	Then I successfully logged in

@regression
Scenario: Check user order history:
	Given I logged in "without" cutting template
	And Basket is empty
	And I am on My Account page
	When I click on Order Hostry
	Then I can see previous orders

@regression
Scenario: Changing GP practice
	Given I login and go through checkout flow to order summary page
	Then I see order summary page
	When I click edit prescription information
	Then I see Reimbursment page
	When I change GP practice
	And I click Save and continue
	Then I see order summary page
	And GP practice is updated
	When I submit order request
	Then Success screen is shown
	And I go through checkout flow to order summary page
	Then I see order summary page
	When I click edit prescription information
	Then I see Reimbursment page
	When I change GP practice back
	And I click Save and continue
	Then I see order summary page
	When I submit order request
	Then Success screen is shown

# This flow is not possible to test by automated scripts anymore
#@regression
#Scenario: Changing exempt status
#	Given I login and go through checkout flow to order summary page
#	Then I see order summary page
#	When I click edit prescription information
#	Then I see Reimbursment page
#	When I change exempt status
#	And I click Save and continue
#	Then I see order summary page
#	And Exempt status is updated
#	When I submit order request
#	Then Success screen is shown
#	Given I am on My Account page
#	When I go to Profile page
#	And Click on Prescription View
#	And I change exempt status back
#	And I Save delivery details
#	Then Exempt status details are updated


