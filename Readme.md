# Case Study - Junior FSE Pre-Requisites MC

## Building multithreaded data-centric applications (C#)

### Problem Statement

Ontime watchstore started business in 2010 as a one stop shop for multi brand wrist watch. It started the business with a single shop selling only Analog watch. They successfully expanded their business in different locations. They also started selling Digital watch as per the customer demand. They want to enhance the user experience specially in big stores in a phased manner.

The problem to solve for Ontime watchstore is to introduce the kiosk for the customer to select a watch from pre-defined catalog and can place  order.

### Proposed Solution

In the first phase, Ontime watchstore needs a solution for creating a kiosk to provide a digital catalog to the customer and placing an order.

### High Level Requirements

The system should be open to add more type of watches and features. Presently, System is being developed to provide the kiosks only in the stores, but may be designed for web access later on. Therefore, the major parts of the system should be based on reusable library.

Customer should be able to select the watch of a specific brand, type of watch and different segments- basis upon features. System should be able to suggest the available options basis upon previous selected choice.

System should be able to record the order information in a persistent data storage to maintain their sale records.

All layers of the application should be tested by writing automated test cases.

To make the system strongly typed while recording the order information, using ORM is suggested.

To make the system robust and preventing abrupt closing, the Development Team should handle the exceptions and errors that can occur in the application.

### Tech Stack

- .Net Framework 4.7+
- Entity Framework 6
- SQL Server 2017
- NUnit

### Milestones 
**Milestone 1: Building Console application (Approx. 2-2.5 hours)**

Step 1: Create a library to define the model classes for your application.

Step 2: Create a library(repository) to store the data into a collection.

Step 3: Define the operations to be performed on the data stored in collection.

Step 4: Create a library(service) to define any business logic for your application.

Step 5: Throw custom exceptions basis upon business rules in the above library.

Step 6: Create a Console application to define the flow of the application using control statements and iterations.

**Milestone 2: Using Database with Entity Framework (Approx. 2 hours)**

Step 1: Create another library to store the Order data in the database.

Step 2: Use Entity Framework 6- 'Code first approach' for database generation.

Step 3: Write the test cases to verify the functionality of your database operations performed.

**Project Structure**
```
📦WatchCart
 ┣ 📂WatchCart.ConsoleApp
 ┃ ┣ 📂Properties
 ┃ ┃ ┗ 📜AssemblyInfo.cs
 ┃ ┣ 📜App.config
 ┃ ┣ 📜packages.config
 ┃ ┣ 📜Program.cs
 ┃ ┣ 📜WatchCart.ConsoleApp.csproj
 ┃ ┗ 📜WatchCartApp.cs
 ┣ 📂WatchCart.Models
 ┃ ┣ 📂Constants
 ┃ ┃ ┣ 📜BrandName.cs
 ┃ ┃ ┣ 📜Segment.cs
 ┃ ┃ ┣ 📜StrapColor.cs
 ┃ ┃ ┣ 📜StrapType.cs
 ┃ ┃ ┗ 📜WatchTypes.cs
 ┃ ┣ 📂Properties
 ┃ ┃ ┗ 📜AssemblyInfo.cs
 ┃ ┣ 📜AnalogWatch.cs
 ┃ ┣ 📜DigitalWatch.cs
 ┃ ┣ 📜Watch.cs
 ┃ ┗ 📜WatchCart.Models.csproj
 ┣ 📂WatchCart.Orders
 ┃ ┣ 📂Properties
 ┃ ┃ ┗ 📜AssemblyInfo.cs
 ┃ ┣ 📜App.config
 ┃ ┣ 📜IOrderRepository.cs
 ┃ ┣ 📜OrderDetails.cs
 ┃ ┣ 📜OrderRepository.cs
 ┃ ┣ 📜packages.config
 ┃ ┣ 📜WatchCart.Orders.csproj
 ┃ ┗ 📜WatchStoreDbContext.cs
 ┣ 📂WatchCart.Repository
 ┃ ┣ 📂Properties
 ┃ ┃ ┗ 📜AssemblyInfo.cs
 ┃ ┣ 📜IWatchCatalog.cs
 ┃ ┣ 📜IWatchRepository.cs
 ┃ ┣ 📜WatchCart.Repository.csproj
 ┃ ┣ 📜WatchCatalog.cs
 ┃ ┗ 📜WatchRepository.cs
 ┣ 📂WatchCart.Service
 ┃ ┣ 📂Properties
 ┃ ┃ ┗ 📜AssemblyInfo.cs
 ┃ ┣ 📜InputValidatorService.cs
 ┃ ┣ 📜InvalidInputException.cs
 ┃ ┣ 📜IWatchService.cs
 ┃ ┣ 📜NoMatchFoundException.cs
 ┃ ┣ 📜WatchCart.Service.csproj
 ┃ ┗ 📜WatchService.cs
 ┣ 📂WatchCart.Test
 ┃ ┣ 📂Properties
 ┃ ┃ ┗ 📜AssemblyInfo.cs
 ┃ ┣ 📜packages.config
 ┃ ┣ 📜ServiceTest.cs
 ┃ ┣ 📜WatchCart.Test.csproj
 ┃ ┣ 📜WatchModelTest.cs
 ┃ ┣ 📜WatchOrderTest.cs
 ┃ ┗ 📜WatchRepositoryTest.cs
 ┣ 📜.gitignore
 ┣ 📜Problem.md
 ┣ 📜Readme.md
 ┗ 📜WatchCart.sln
 ```



### `Refer to Problem.md for further instructions`