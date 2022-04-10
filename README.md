# The Mediator Pattern and CQRS sample project

## Setup

- SQLite has been used as database
- You can change connection string from *appsettings.json* within *aspnetcore-mediator.API*
- Apply database migrations to create the tables. From a command line within the **aspnetcore-mediator.Persistence** project folder use the dotnet CLI to run :

```
dotnet ef --startup-project ../aspnetcore-mediator.API migrations add InitialMigration --context DataContext
```
```
dotnet ef --startup-project ../aspnetcore-mediator.API database update InitialMigration --context DataContext
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## Show your support

Give a ⭐️ if this project helped you!
