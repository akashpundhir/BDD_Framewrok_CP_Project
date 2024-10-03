Feature: 2_Profile
A short summary of the feature
Background:
	Given Edge browser is started
	And Professional site is opened
	And User accepted the cookies
@regression
Scenario: Check newly created profile
	Given User clicks Login
	And User clicks Sign Up now
	When User fills info
	And User creates new B2C Account
	Then Account is created
	When User opens profile
	Then Profile overview is opened
	When User opens Personal info
	Then Personal info is shown correctly - newly created profile
	When User opens Certicates info
	Then Certificates are empty
	When User opens E-Learning access info
	Then E-Learning access info is shown correctly - newly created profile
	When User opens Notifications info
	Then Notifications info is shown correctly - newly created profile
@regression
Scenario: Update newly created profile
	#Given User is signed in with newly created profile
	Given User clicks Login
	And User clicks Sign Up now
	When User fills info
	And User creates new B2C Account
	Then Account is created
	When User opens profile
	And User opens Personal info
	And User updates country to 'Germany'
	When User opens profile
	And User opens Personal info
	Then Profile is updated and country is 'Germany'
@regression
Scenario: login and Update Personal Info, Bookmarks, E-leraning access, notifications and etc.
	Given User clicks Login
	Then I logged in successfuly
	When User opens profile
	Then Profile overview is opened
	When User opens Personal info
	Then I update details like First name Last name Medical specialty Registration number,etc.
	Then I click on logout and test completed successfully
@regression
Scenario: User navigated to Event page
	Given User clicks Login
	Then I logged in successfuly
	Given user is open Event page
	Then I verified event page componenet its details and test completed successfully
@regression
Scenario: User open Media page
	Given user is navigate to  meida page
	Then user read introduction and author details
	Then user played and audio podcast
	Then user scroll to rich text section
	Then user click play video button
	Then user open FAQ
	Then user successfully verified component on media page
@regression
Scenario: User open HCP Page
	Given user is navigate to  hcp page
	Then user read introduction, heading, text, content and buttons
	Then user play podcast on HCP page
	Then user scroll to rich text section to verify text and heading
	Then user play video HCP Page
	Then user open hcp page FAQ
	Then user successfully verified component on HCP page
@regression
Scenario: User Hover menu on the  Page
	Given user is hovering resources
	Then user successfully verified menu layer navigation
@regression
Scenario: User open Course Page
	Given user is navigate to  course page and veirfied components
	Then user read course details, name, length, enorsed by, category etc.
	Then user open FAQ section
	Then user play video
	Then user successfully verified component on course page
@regression
Scenario: User open Theme Page
	Given user is navigate to  theme page and veirfied components
	Then user read intoduction, verified tagging,recommended block and other details
	Then user successfully verified component on theme page
@regression
Scenario: User open Product Page
	Given user is navigate to  product page and veirfied components
	Then user verify page components like Richtext, Product,Varient and etc
	Then user scroll down and click pulsating icon and read the text
	Then user scroll up and pause the video
