Feature: ManageListingsTask2
	As a SkillSwap member
	I want to edit and delete the skills in my profile

@EditManageistings
Scenario Outline: Editing Skill
	Given I am logged into the profile and click on ManageListings tab
	And click the Edit button of '<EditSkill>'
	When I entered the details of skill
	Then the '<EditSkill>' item should be added in the ManageListings tab
	Examples: 
	| EditSkill | 
	| Selenium  |

@DeleteManageistings
Scenario Outline: Deleting Skill
	Given I am logged into the profile and click on ManageListings tab
	And click the Delete button of '<DeleteSkill>'
	Then the '<DeleteSkill>' should be removed from ManageListings tab
	Examples: 
	| DeleteSkill |
	| Selenium    |

