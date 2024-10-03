Feature: 2_SignUp
	As a user I want to Sign Up to the Charter

Background: 
	Given Edge browser is started
	And Charter site is opened

@regression
Scenario: Check SignUp flow is started
	When I click register
	Then B2C page is opened

@regression @smoke
Scenario: Create new B2C account
	Given SignUp flow is started
	When I enter new email
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click Create account button
	And I fullfil personal details
	Then New account is created
	#And I clicked Go to My Profile
	#When I go to Profile page
	#And Click on Delivery Info View
	#And I type a valid postcode
	#And I Save delivery details
	#Then Delivery details are updated

@regression
Scenario: User can reset the password
	Given SignUp flow is started
	When I enter new email
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click Create account button
	And I fullfil personal details
	Then New account is created
	And I want browser to be restarted
	And Charter site is opened
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
#Scenario: Fill delivery info
#	Given B2C account is created
#	And I clicked Go to My Profile
#	When I go to Profile page
#	And Click on Delivery Info View
#	And I type a valid postcode
#	And I Save delivery details
#	Then Delivery details are updated
	
	