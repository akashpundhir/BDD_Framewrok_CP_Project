Feature: 1_Basic
As user I want to check that Lilial is opened and I can login

Background: 
	Given Edge browser is started
	And Lilial site is opened

@smoke @regression
Scenario: Check Lilial opened
	Then Main page is opened

@smoke @regression
Scenario: Login to Lilial
	When I press login button
	And I enter email for account "without" cutting template
	And I enter password
	And I press log in button
	Then I successfully logged in