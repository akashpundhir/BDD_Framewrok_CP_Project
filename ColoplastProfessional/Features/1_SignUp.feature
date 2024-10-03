Feature: 1_SignUp

	As a user I want to Sign Up to the Coloplast Professional

Background: 
	Given Edge browser is started
	And Professional site is opened
	And User accepted the cookies

@regression
Scenario: SignUp with a new user
	Given User clicks Login
	And User clicks Sign Up now
	When User fills info
	And User creates new B2C Account
	Then Account is created

@regression
Scenario: User can reset the password
	Given User clicks Login
	And User clicks Sign Up now
	When User fills info
	And User creates new B2C Account
	Then Account is created
	And I want browser to be restarted
	And Professional site is opened
	When User clicks Login
	And I click forgot password
	Then I see reset password flow is started
	When I write email address
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click continue
	Then I successfully logged in

#@regression
#Scenario: SignUp with a new user - Complete profile
#	Given User clicks Login
#	And User clicks Sign Up now
#	When User fills info
#	And User creates new B2C Account
#	When User fills Complete profile
#	Then Account is created - 'explore-training' page is shown

