Feature: ProfileFeatures
	As a SkillSwap member
	I want to change the password of profile if needed

@ProfileFeatures
Scenario Outline: ChangePassword
	Given I logged in the system and click on Profile DropDown box
	And Click on ChangePassword Button
	When I provide the value for fields '<Old Password>', '<New Password>' and '<Confirm Password>' 
	Then the password should change successfully by returning to home page
	Examples: 
	| Old Password |  | New Password |  | Confirm Password |  
	| test@123     |  | test123      |  | test123          |

