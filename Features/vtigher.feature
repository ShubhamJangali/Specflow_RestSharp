@vtiger
Feature: Vtiger Application

Scenario: Verify Login
Given User is on Login Page 
Then Enter valid credential
And click on Login button
Then verify home page
Then close the browser