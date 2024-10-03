Feature: 3_Menu

A short summary of the feature

Background:
	Given Edge browser is started
	And Professional site is opened
	And User accepted the cookies

@regression
Scenario: Check 'All about stoma'
	Given User is clicked 'Resources' - 'Knowledge' - 'Stoma'
	When User is clicked 'All about stoma'
	Then Course card is shown

@regression
Scenario: Check 'Bowel Management'
	Given User is clicked 'Resources' - 'Clinical Evidence'
	When User is clicked 'Bowel Management'
	Then Course card is shown