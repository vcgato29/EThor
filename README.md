# EThor
This is a simple win-forms application consisting of a window with a start/stop button. The intial text on the button is 'Start'. When pressed execution starts and the button changes to 'Stop'.

During execution, the application does the following:
1. Retrieve a JSON formatted string from this URL:http://test.ethorstat.com/test.ashx
2. Perform the math operation requested. The operation is either +,-,/,*
3. Show the full equation and result in the window. Example “3 + 5 = 8”
4. All the operations are logged into a scrollable grid view.

## Getting Started: 
 - You will need .NET Framework 4.6 or above to run this application. 
 - This application makes use of Nuget packages and hits an external URL to obtain data for the operations. So an internet connection is    required to run this application.

## Libraries/Components Used:
- BackgroundWorker - The backgroundworker thread is the crux of this application. In-order to keep the UI responsive during the execution and to signal start/stop the execution, backgroundworker is a preferred way of implementing.
- NInject - For dependency-injection
- HttpClient - To make the Http Web Request that fetches the Json for the operation
- JavaScriptSerializer - To parse the json and convert it into a type
- Visual Studio Unit Testing Framework - For writing unit test cases
- Moq - For mocking DataProviders and external dependencies.

## Tests
Unit Test Cases are written using Visual Studio Test Framework/Moq. They can be run within Visual Studio.
