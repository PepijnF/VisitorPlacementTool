Feature: VisitorPlacement
	Simple calculator for adding two numbers

@mytag
Scenario: There are more visitors than chairs
	Given there are 1 sections
	And the section has 2 rows
	And every row has 5 seats
	Given there are 12 visitors
	Then all seats should be filled
	
Scenario: There are multiple groups and individuals
	Given there are 2 groups each has 5 people
	And 10 individual visitors
	And there are 2 sections
	And the section has 10 rows
	And every row has 3 seats
	Then not all seats should be filled