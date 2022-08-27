
# Ticket Purchase System

Simple CRUD application built with ASP.NET MVC Web Application. This project is built with a view to exploring Layered
Architecture and implementing Repository and Unit of Work design patterns.

## Demo

![TicketPurchaseSystem](https://github.com/nayeemsweb/Ticket-Purchase-System/blob/main/docs/TicketPurchaseSystem.gif?raw=true)


## Installation

Firstly, clone the project-
```
https://github.com/nayeemsweb/Ticket-Purchase-System.git
```
Secondly, Open the project in Visual Studio by running the `TicketPurchase.sln` solution file - 
```
cd Ticket-Purchase-System/src/TicketPurchase
```
Thirdly, From the `Tools` menu go to `NuGet Package Manager` option and click to
`Package Manager Console`. Now, update migration using the following command - 
```
dotnet ef database update --project TicketPurchase.Web --context PurchasingDbContext
```
This will create a database named `TicketPurchaseDb` in your SQL Server (actually SSMS) and
also the table(s) accordingly.

⚠️ ***Your must have `SQL Server` and* `SQL Server Management Studio` 
installed on your machine.***


## Environment Variables

In the `Ticket-Purchase-System/src/TicketPurchase.Web/` path there is a file named 
`appsettings.json`. If you face in updating the migration then configure this line - 
```
"DefaultConnection": "Server=.\\SQLEXPRESS;Database=TicketPurchaseDb;Trusted_Connection=True;"
```
You may change the `Server` vaule according to your configuration.


## Tech Stack

**Backend:** ASP.NET (Core) 6, Entity Framework (Core), Sql Server

**Logger:** Serilog

**Design Patterns:** Repository & Unit of Work

**Architecture:** Layered Architecture (UI, Business Logic & Data Access Layer)

**Frontend:** AdminLTE Dashboard Template, Bootstrap




## Features

- Ticket Purchase CRUD
- Ajax Search
- Pagination
- Client Side & Server Side Validation


## Support

❤️ If you do like my work, hit the ⭐️ button above. ❤️


## License

[MIT](https://choosealicense.com/licenses/mit/)

