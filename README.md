# Dev Assessment

## Stored Procedure
- Navigate to  : northwind/pr_GetOrderSummary.sql

## Web Api

### Setup
- Install .NET 7 Core, tested with Ubuntu 20.04 : https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu-2004
- Requires sqlite3 db to be installed

### Run API Server
- Navigate to : roulette/RouletteService
- Execute :
    - dotnet build
    - dotnet run

### Run Tests
- Navigate to : roulette/RouletteService.Tests
- Execute :
    - dotnet build
    - dotnet test

### JSON Requests
- Create game : POST - https://localhost:5001/api/game
    - { "MinBet" : 6 }
- Get game : GET - https://localhost:5001/api/game/1
- Create player : POST - https://localhost:5001/api/player
    - { "Name" : "Jeff" }
- Create bet : POST - https://localhost:5001/api/bet
    - { "Type" : "NUMBER", "Number" : 15, "GameId" : 1, "PlayerId" : 1, "Amount" : 10 }
- Create bet : POST - https://localhost:5001/api/spin
    - { "Number" : 15, "GameId" : 1 }

### Database
- To access database navigate to  : roulette/RouletteService
- Execute : sqlite3 roulette.database