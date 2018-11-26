# CleanSpark Back-End Developer Test Specification

## Purpose/Responsibilities

A .NET application that mimics the functionality of a coffee vending machine. Provides the means of ordering one or more customizable cups of coffee, providing payment, receiving change, and dispensing the correct product.

## Assumptions/Constraints

- Built in C# 4.6.2+
- Front end can be web/windows/console; whatever is easiest as long as all functionality can be exercised through it.
- Does not depend on any external web services.
- Does not require a persistent database store.

## Functionality/Tasks Performed

- Order coffee in 3 sizes (small for $1.75, medium for $2.00, large for $2.25).
- Allow adding sugar and cream in discrete increments to each coffee order (from 1 –3 sugars ($0.25 each) and from 1 –3 creamers ($0.50 each)).
- “Dispense” coffee when an order is completed if adequate payment has been provided,and display money remaining in payment transaction.
- Give warning if adequate payment has not been provided.
- Allow multiple coffee orders per payment transaction.
- Allow adding money in standard monetary increments (from $0.05 to $20).
- Allow user to specify the end of a payment transaction and dispense change.
- Developer should provide a minimum set of passing unit tests

## Evaluation Criteria

We are looking for concise and readable code that meets the component specifications. Where the component specifications are ambiguous or lacking, we are looking foryou to make a decision that allows you to move forward without compromising the basic functionality of the application. We are expecting this task to take you 1-3 hours; please do not spend more than 5 hours on this task.

## Running the app

1. Clone or Download this repository using your favorite tool or command line
2. Open the cloned/downloaded solution in Visual Studio
3. Build/Run the project
4. Open your favorite browser and navigate to the following url: http://localhost:65245/VendingMachine/Index
5. Rejoice!

**NOTE: It may automatically open in a browser but at the root level of http://localhost:65245/, if so, simply change the url to the one in step 4.**