Feature: ICEnrollment

Verify IC various enrollments

Background: 
	Given Edge browser is started
	And Careconnect site is opened

@smoke @regression
Scenario: Guest enrollment - Quick form
	Given Guest enrollment is opened
	When User selects new continence enrollment
	And User selects Quick form
	And User fills Patient info - First Name is 'TESTIC'
	And User fills Care advisor info
	And User fills Prescription details
	And User fills Supplier and documentation
	And User fills Identify healthcare provider
	And User fills Sign and Submit prescription
	And User signs Enrollment form via DocuSign
	Then Form is signed

@smoke @regression
Scenario: Guest enrollment - Send to Provider
	Given Guest enrollment is opened
	When User selects new continence enrollment
	And User selects Product catalog
	And User fills Patient info - First Name is 'TESTIC'
	And User selects Product 'SpeediCath® Compact Male with SpeediBag'
	And User fills Prescription details - other
	And User fills Supplier and documentation
	And User fills Identify healthcare provider
	And User fills Sign and Submit prescription - Send to Provider
	And User signs Enrollment form via DocuSign
	Then Form is signed

@smoke @regression
Scenario: Guest enrollment - Sign as HCP
	Given Guest enrollment is opened
	When User selects new continence enrollment
	And User selects Product catalog
	And User fills Patient info - First Name is 'TESTIC'
	Then Patient info is shown correctly - Firs Name is 'TESTIC'
	When User selects Product 'SpeediCath® Compact Male with SpeediBag'
	Then Product is shown correctly 'SpeediCath® Compact Male with SpeediBag'
	When User fills Prescription details - other
	Then Prescription details are shown correcly - other
	When User fills Supplier and documentation
	When User fills Identify healthcare provider
	Then Identify healthcare provider is shown correctly
	When User fills Sign and Submit prescription - Sign now
	And User signs Enrollment form via DocuSign - Self sign
	Then Form is signed - self sign

@smoke @regression
Scenario: Enrollment - Quick form
	Given User is signed in
	When User selects new continence enrollment from menu
	And User selects Quick form
	And User fills Patient info - First Name is 'TESTIC'
	And User clicks Close on draft popup
	Then Patient info is shown correctly - Firs Name is 'TESTIC'
	When User fills Care advisor info
	And User clicks Close on draft popup
	Then Care advisor info is shown correctly
	When User fills Prescription details - other
	And User clicks Close on draft popup
	Then Prescription details are shown correcly - other
	And Facility info is shown
	When User fills Supplier and documentation
	And User clicks Close on draft popup
	And User fills Sign and Submit prescription
	And User signs Enrollment form via DocuSign
	Then Form is signed
	And Form is submitted on dashboard for 'TESTIC' with type 'Continence' and 'Care advisor choice' sampled products

@smoke @regression
Scenario: Enrollment - Send to Provider
	Given User is signed in
	When User selects new continence enrollment from menu
	And User selects Product catalog
	And User fills Patient info - First Name is 'TESTIC'
	And User clicks Close on draft popup
	And User selects Product 'SpeediCath® Compact Male with SpeediBag'
	And User clicks Close on draft popup
	And User fills Prescription details - other
	And User clicks Close on draft popup
	And User fills Supplier and documentation
	And User clicks Close on draft popup
	And User fills Sign and Submit prescription - Send to Provider
	And User signs Enrollment form via DocuSign
	Then Form is signed
	And Form is submitted on dashboard for 'TESTIC' with type 'Continence' and 'SpeediCath® Compact Male with SpeediBag' sampled products

@smoke @regression
Scenario: Enrollment - Sign as HCP
	Given User is signed in
	When User selects new continence enrollment from menu
	And User selects Product catalog
	And User fills Patient info - First Name is 'TESTIC'
	And User clicks Close on draft popup
	And User selects Product 'SpeediCath® Compact Male with SpeediBag'
	And User clicks Close on draft popup
	And User fills Prescription details - other
	And User clicks Close on draft popup
	And User fills Supplier and documentation
	And User clicks Close on draft popup
	And User fills Sign and Submit prescription - Sign now
	And User signs Enrollment form via DocuSign - Self sign
	Then Form is signed - self sign
	And Form is submitted on dashboard for 'TESTIC' with type 'Continence' and 'SpeediCath® Compact Male with SpeediBag' sampled products
