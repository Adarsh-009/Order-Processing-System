**Order Processing System Web API**

**Description**

This project implements a Web API in .NET 6 for an Order Processing System. The API provides functionalities for creating orders, retrieving lists of orders, and obtaining detailed information about specific orders.

**Features**
* Create Order: Endpoint to create a new order with customer details and product information.
* List Orders: Endpoint to retrieve a list of orders with basic information.
* Get Order Detail: Endpoint to retrieve detailed information about a specific order.

**Technologies Used**
* .NET 6
* ASP.NET Core
* Entity Framework Core
* SQL Server
* Swagger/OpenAPI
* Dependency Injection (IoC)

**Installation**
1. Clone the repository: 'git clone https://github.com/Adarsh-009/Order-Processing-System.git'
2. Navigate to the project directory: 'cd your-repository'
3. Restore dependencies: 'dotnet restore'
4. Update database: 'dotnet ef database update'
5. Run the project: 'dotnet run'

**API Endpoints**

POST '/API/Order'

Creates a new order with the provided payload.

GET '/API/Order'

Retrieves a list of orders with basic information.

GET '/API/order/{orderId}'

Retrieves detailed information about a specific order.
