Feature: OCEnrollment

Verify OC various enrollments

Background: 
	Given Edge browser is started
	And Careconnect site is opened
	
@smoke @regression
Scenario: Guest enrollment - Care Advisor
	Given Guest enrollment is opened
	When User selects new ostomy enrollment
	And Guest selects Care Advisor form
	And User fills Patient info - First Name is 'TESTOC'
	And User fills Patient Condition info
	And User fills Supplier and documentation
	And User fills Identify healthcare provider
	And Confirm submitting as a guest
	Then OC Form is signed

@smoke @regression
Scenario: Guest enrollment - Product catalog
	Given Guest enrollment is opened
	When User selects new ostomy enrollment
	And Guest selects OC Product catalog
	And User fills Patient info - First Name is 'TESTOC'
	Then Patient info is shown correctly - Firs Name is 'TESTOC'
	When User fills Patient Condition info
	Then Patient Condition info is shown correctly
	When User selects Product 'SenSura® Mio Convex Flip 1-piece closed'
	Then Product is shown correctly 'SenSura® Mio Convex Flip 1-piece closed'
	When User fills Supplier and documentation - Preferred supplier
	Then Supplier and documentation is shown correctly
	When User fills Identify healthcare provider
	And Confirm submitting as a guest
	Then OC Form is signed

@smoke @regression
Scenario: Guest enrollment - Educational
	Given Guest enrollment is opened
	When User selects new ostomy enrollment
	And Guest selects Educational
	And User fills Patient info - First Name is 'TESTOC'
	And User fills Patient Condition info
	And User fills Supplier and documentation - Preferred supplier
	And User fills Identify healthcare provider
	And Confirm submitting as a guest
	Then OC Form is signed

@smoke @regression
Scenario: Enrollment - Care Advisor - Hospital delivery
	Given User is signed in
	When User selects new ostomy enrollment from menu
	And User selects Care Advisor form
	And User fills Patient info - Hospital delivery - First Name is 'TESTOC'
	And User clicks Close on draft popup
	Then Patient info is shown correctly - Firs Name is 'TESTOC'
	When User fills Patient Condition info
	And User clicks Close on draft popup
	Then Patient Condition info is shown correctly
	And Facility info is shown
	When User fills Supplier and documentation
	Then OC Form is signed
	And Form is submitted on dashboard for 'TESTOC' with type 'Ostomy' and 'Care advisor choice' sampled products

@smoke @regression
Scenario: Enrollment - Product catalog
	Given User is signed in
	When User selects new ostomy enrollment from menu
	And User selects OC Product catalog
	And User fills Patient info - First Name is 'TESTOC'
	And User clicks Close on draft popup
	And User fills Patient Condition info
	And User clicks Close on draft popup
	And User selects Product 'SenSura® Mio Convex Flip 1-piece closed'
	And User clicks Close on draft popup
	And User fills Supplier and documentation - Preferred supplier
	Then OC Form is signed
	And Form is submitted on dashboard for 'TESTOC' with type 'Ostomy' and 'SenSura® Mio Convex Flip 1-piece closed' sampled products

@smoke @regression
Scenario: Enrollment - Educational
	Given User is signed in
	When User selects new ostomy enrollment from menu
	And User selects Educational
	And User fills Patient info - First Name is 'TESTOC'
	And User clicks Close on draft popup
	And User fills Patient Condition info
	And User clicks Close on draft popup
	And User fills Supplier and documentation - Preferred supplier
	Then OC Form is signed
	And Form is submitted on dashboard for 'TESTOC' with type 'Ostomy' and 'Educational Kit' sampled products