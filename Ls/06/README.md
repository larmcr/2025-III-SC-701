# Lección 6

## Entity Framework

```
dotnet tool list --global

dotnet tool install --global dotnet-ef --version 9

dotnet tool update --global dotnet-ef --version 9.0.10

dotnet ef
```

## Solution

```
dotnet new sln -n Lec06
```

## Code First

```
dotnet new console -o CodeFirst -f net8.0

dotnet sln add CodeFirst

dotnet add package Microsoft.EntityFrameworkCore.Sqlite

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet ef migrations add InitialCreate

dotnet ef database update
```

## Database First

```
dotnet new console -o DatabaseFirst

dotnet sln add DatabaseFirst

dotnet add package Microsoft.EntityFrameworkCore.Sqlite

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet ef dbcontext scaffold "Data Source=./BankDf.db" Microsoft.EntityFrameworkCore.Sqlite -o DbModel
```
