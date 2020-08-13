Feature: SomeBasicSpecFlowWebTests
	

	@tag1
Scenario: Basic test google
	Given I go to Google gomepage
	And I enter "Brighton" into the search box
	When I press search button
	Then I should be directed to search results page

	@tag2
Scenario: Find on RightMove
	Given I navigate to "https://www.rightmove.co.uk/"
	When I enter "Patcham" into search box
	And I click For Sale
	When I enter 
	| SearchRadius  | PriceRangeMin | PriceRangeMax | BedroomsMin | BedroomsMax | PropType | Added        | STC |
	| Within ½ mile | 80,000        | 650,000       | 4           | 5           | Houses   | Last 14 days | no |
 	And I click findproperties
	Then I should be on page "Houses For Sale in Patcham"
	And There shouild be "10 results" results

Scenario: Search council website
	Given I navigate to "http://new.brighton-hove.gov.uk/"
	When I click on bin collections 
	And I select start
	And I enter postcode "BN1 8UG"
	And I click find addess and enter "25 Craignair Avenue  Brighton BN1 8UG"
	And I click next collections

Scenario Outline: Search council website multiple times
	Given I navigate to "http://new.brighton-hove.gov.uk/"
	When I click on bin collections 
	And I select start
	And I enter postcode "<postcode>"
	And I click find addess and enter "<houseaddress>"
	And I click next collections

	Examples: 
	| postcode | houseaddress                          |
	| BN1 8UG  | 25 Craignair Avenue  Brighton BN1 8UG |
	| BN1 8UH  | 36 Craignair Avenue  Brighton BN1 8UH |


Scenario: Test data from JSON file
	Given I navigate to "http://new.brighton-hove.gov.uk/"
	When I click on bin collections 
	And I select start
	Given I enter address and postcode from file
	When I pass the adrress and postcode to this step
	And I click next collections

	@mytag1 @mytag2
Scenario: A scenario context test
	Given I have the following data
	| Field | Value            |
	| One   | Test data part 1 |
	| Two   | Test data part 2 |
	Then I can see the above data in the scenario