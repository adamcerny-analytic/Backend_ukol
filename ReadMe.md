Terminal ve VSC
1. docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Heslo123" -p 1433:1433 --name sqlserver2022 -d mcr.microsoft.com/mssql/server:2022-latest



docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Heslo123" \
   -p 1433:1433 --name sqlserver2022 \
   --platform linux/amd64 \
   -d mcr.microsoft.com/mssql/server:2022-latest


2. docker ps

Otevřít VS Code SQL extension nebo Azure Data Studio

Server: localhost,1433
Authentication: SQL Login
User: sa
Password: Heslo123

3. Vytvořit databázi (pokud ještě neexistuje):
CREATE DATABASE RequestsDb;
GO

4. Otevřít soubor RequestsDb.sql z projektu a spustit ho –  vytvoří tabulku Requests a vloží testovací data.
 
 5. dotnet run
 6. test přes swagger