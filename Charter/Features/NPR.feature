Feature: 4_NPR
	As a new user I want to be able to order 

Background: 
	Given Edge browser is started
	And Charter site is opened

@regression
Scenario: Order a product as NPR user
	Given SignUp flow is started
	When I enter new email
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click Create account button
	And I fullfil personal details
	Then New account is created
	When I am on a "SenSura" product page
	And I selected standard "SenSura" pack
	And I pressed Add to basket
	And I go to checkout
	Then I see Complimentary item page
	When I "do not add" complimentary item
	Then I see Delivery detail page
	When I fill delivery details
	And I click Save and continue
	Then I see Reimbursment page
	When I fill prescription information
	And I click Save and continue
	Then I see Order Consent Page
	When I click accept and continue
	Then I see Marketing permission page
	When I click Skip
	Then I see order summary page
	When I submit order request
	Then Success screen is shown

@regression
Scenario: NPR user doesn't accept consent
	Given SignUp flow is started
	When I enter new email
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click Create account button
	And I fullfil personal details
	Then New account is created
	When I am on a "Brava" product page
	And I selected standard "Brava" pack
	And I pressed Add to basket
	And I go to checkout
	Then I see Complimentary item page
	When I "do not add" complimentary item
	Then I see Delivery detail page
	When I fill delivery details
	And I click Save and continue
	Then I see Reimbursment page
	When I fill prescription information
	And I click Save and continue
	Then I see Order Consent Page
	When I click cancel
	Then I am redirected to Home Page

@regression
Scenario: NPR added sample before registration
	Given I am on a "Adhesive" product page
	And I selected sample
	And I pressed Add to basket
	Then Login to your account modal is shown
	When I click register
	And I enter new email
	And Click Send code button
	And I got verification code from email
	And Create a new password
	And I click Create account button
	And I fullfil personal details
	Then I can see modal 'Account created'
	And Sample of "Adhesive" is added to the basket
