Feature: 2_SignUp
	As a user I want to Sign Up to the Lilial

Background: 
	Given Edge browser is started
	And Lilial site is opened

@smoke
Scenario: Check SignUp flow is started
	When I click register
	Then B2C page is opened

@smoke
Scenario: Create new B2C account and Fill delivery info
	Given SignUp flow is started
	When I enter new email
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click Create account button
	Then New account is created
	#And I clicked Go to My Profile
	#When I go to Profile page
	#And Click on Delivery Info View
	#And I type a valid postcode
	#And I Save delivery details
	#Then Delivery details are updated

@smoke
Scenario: User can reset the password
	Given SignUp flow is started
	When I enter new email
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click Create account button
	#And I fullfil personal details
	Then New account is created
	And I want browser to be restarted
	And Lilial site is opened
	When I press login button
	And I click forgot password
	Then I see reset password flow is started
	Then I successfully logged in