Steps to run the Random User App:

1. Clone the repository
2. Open solution in VS 22, build it and run the RandomUser.App project
3. You can view the OpenAPI documentation by adding '/swagger' in suffix (https://localhost:7226/swagger)
4. Below are the Postman API calls:

HealthCheck => curl --location 'https://localhost:7226/user/healthcheck'

GetRandomUser => curl --location 'https://localhost:7226/user/randomuser' \ --header 'Authorization: Basic cmFuZG9tdXNlcjpQYXNzd29yZEAxMjM='

5. You can also find the test cases for both in RandomUser.Tests project
6. Open ClientApp (inside RandomUser.App) in terminal and perform following steps:

ng build

ng serve

7. Angular app shall start on localhost random port
8. Copy that URL and paste it in browser
9. Everytime you refresh the page you should be able to see a random user denoting the GetRandomUser API being called.

Note: You might get CORS issue which would show blank screen and a related error in console. In order to make the App work, run the Angular App in disabled security chrome window. Steps to open the window is simple: Press Windows+R and paste this command => chrome.exe --user-data-dir="C:/Chrome dev session" --disable-web-security
