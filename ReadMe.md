1. git clone https://github.com/adamcerny-analytic/Backend_ukol.git
2. docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Heslo123" -p 1433:1433 --name sqlserver2022 -d mcr.microsoft.com/mssql/server:2022-latest
3. docker ps

Otevřít VS Code SQL extension nebo Azure Data Studio

Server: localhost,1433
Authentication: SQL Login
User: sa
Password: Heslo123

4. Vytvořit databázi (pokud ještě neexistuje):
CREATE DATABASE RequestsDb;
GO

5. Otevřít soubor RequestsDb.sql z projektu a spustit ho –  vytvoří tabulku Requests a vloží testovací data.
 
 6. dotnet run
 7. test přes swagger