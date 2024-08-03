Feature: APIs Testing

@Get
Scenario: Test GET Method
Given the base URL is "https://reqres.in/"
When and the endpoint url is "/api/users/2"
And perform get operation 
Then print the response