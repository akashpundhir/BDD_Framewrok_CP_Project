Feature: 2_SignUp
	As a user I want to Sign Up to the Multisite

Background: 
	Given Edge browser is started
	And Multisite site is opened

@regression
Scenario: Check SignUp flow is started
	When I click register
	Then B2C page is opened

@regression @smoke
Scenario: Create new B2C account and Fill profile info
	Given SignUp flow is started
	When I enter new email
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click Create account button
	Then New account is created
	#And I clicked Complete My Profile
	#And I clicked Contact Details
	#When I fill Profile data
	#And I save changes
	#Then Profile is saved

@regression
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
	And Multisite site is opened
	When I press login button
	And I click forgot password
	Then I see reset password flow is started
	When I write email address
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click continue
	Then I successfully logged in

#@smoke @regression @newaccount
#Scenario: Fill profile info
#	Given B2C account is created
#	And I clicked Complete My Profile
#	And I clicked Contact Details
#	When I fill Profile data
#	And I save changes
#	Then Profile is saved
	