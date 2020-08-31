Feature: ManageListings
	As a SkillSwap member
	I want to edit and delete the skills in my profile

@EditManageistings
Scenario Outline: Editing Skill
	Given I am logged into the profile with '<username>'and '<pwd>' and click on ManageListings tab
	And click the Edit button of '<EditSkill>'
	When I entered the details of skill
	Then the '<EditSkill>' item should be added in the ManageListings tab
	Examples: 
	| username                  |  | pwd      |  | EditSkill | 
	| keerthi.jampani@gmail.com |  | test123  |  | Selenium  |

@DeleteManageistings
Scenario Outline: Deleting Skill
	Given I am logged into the profile with '<username>' and '<pwd>' and click on ManageListings tab
	And click the Delete button of '<DeleteSkill>'
	Then the '<DeleteSkill>' should be removed from ManageListings tab
	Examples: 
	| username                  |  | pwd      |  | DeleteSkill |
	| keerthi.jampani@gmail.com |  | test123  |  | Selenium    |

