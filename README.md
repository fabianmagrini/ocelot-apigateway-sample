# Api Gateway using Ocelot

## Create apps
```sh
dotnet new sln
dotnet new web -o Gateway
dotnet new webapi -o Api.ServiceA
dotnet new webapi -o Api.ServiceB
```

## Build
```sh
docker-compose build
```

## Run
```sh
docker-compose up
```

## Creating the Gateway

```sh
dotnet add package Ocelot
```
