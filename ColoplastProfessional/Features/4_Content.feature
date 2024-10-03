Feature: 4_Content

Check different page types

Background: 
	Given Edge browser is started
	And Professional site is opened
	And User accepted the cookies

#@regression
#Scenario: HCP Article page
#	Given User searches 'Automation'
#	When User is clicked search result 'HCP Article'
#	Then Article page is opened and content is shown correct
#
#@regression
#Scenario: HCP Theme page
#	Given User searches 'Automation'
#	When User is clicked search result 'HCP Theme'
#	Then Theme page is opened and content is shown correct
#
#@regression
#Scenario: Login to ShowPad
#	Given User is signed in with newly created profile
#	And User click on Logo to redirect on main page
#	And User searches 'Course challenge_Start Course'
#	And User is clicked first search result
#	When User is clicking Start Course
#	Then Showpad is opened
