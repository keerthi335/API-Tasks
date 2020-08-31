Feature: ShareSkill
	As a SkillSwap member
	I want to add my skills to share in the profile

@ShareSkill Feature
Scenario: Adding Skill
	Given I am logged into the profile and clicked the ShareSkill button
	When I entered the skill details
	Then the new skill should be added in the ManageListings tab
