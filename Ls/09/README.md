# Lección 09

```
dotnet new sln -n Lec09
```

## MVC

```
dotnet new mvc -o MVC

dotnet sln add MVC
```

## Razor Pages

```
dotnet new webapp -o RP

dotnet sln add RP
```

```
cd Pages

dotnet new page -n MyList --namespace RP.Pages
```

## Empty Project

```
dotnet new web -o EP

dotnet sln add EP
```

## ML .NET

https://dotnet.microsoft.com/en-us/learn/ml-dotnet/get-started-tutorial/intro

```
dotnet tool list --global

dotnet tool search mlnet

dotnet tool install -g mlnet-win-x64
```