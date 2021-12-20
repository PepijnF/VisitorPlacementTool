Feature: VisitorPlacement
	Visitor placment tool

@mytag
Scenario: There are more visitors than chairs
	Given there are 1 sections
	And the section has 2 rows
	And every row has 5 seats
	Given there are 12 visitors
	Then all seats should be filled
	
Scenario: There are multiple groups and individuals
	Given there are 2 groups each has 5 people
	And 5 individual visitors
	And there are 1 sections
	And the section has 2 rows
	And every row has 3 seats
	Then all seats should be filled
	
Scenario: There are multiple groups and individuals, but not enough seats in a single section
	Given there are 2 groups each has 6 people
	And 3 individual visitors
	And there are 2 sections
	And the section has 2 rows
	And every row has 4 seats
	Then not all seats should be filled
	
Scenario: Group split over 2 sections
	Given there are 1 groups each has 16 people
	And 0 individual visitors
	And there are 2 sections
	And the section has 2 rows
	And every row has 4 seats
	Then all seats should be filled