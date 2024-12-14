## Description:

We have a older Calculator API that must be extended a bit. 

Below is the four user stories.

User Stories

### 1 Extend Logging System
Currently we only log to SQL. Now we also wants logs to a file and written to console.
Please implement this functionality.

### 2 Division functionality
Customers require a API that allows for division, please extend the functionality to allow for that usage

### 3 Add more than two numbers 
Customers need a API to add up to five numbers, please extend the functionality to allow for that usage

### 4 Temperature near your home town
We want to extend out API functionality so the customer to be able to see temperature near their home town using data from https://www.weatherapi.com/ 
Implement an API that takes city at input, fetches data from https://www.weatherapi.com/ and then returns the data to the user.
We use System.Net.Http.HttpClient for http client communication.
