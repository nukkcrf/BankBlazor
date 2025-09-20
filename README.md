
# Bankapplikation

## Översikt

Detta projekt är ett enkelt banksystem som jag utvecklat som en del av mina studier i .NET. Syftet var att öva på att arbeta med **Blazor WebAssembly** som klient och ett **.NET Web API** som backend. Applikationen hanterar grundläggande bankfunktioner som att visa konton, insättningar, uttag och överföringar. All data sparas i en SQL Server-databas och **Entity Framework Core** används för kommunikationen mellan API\:t och databasen.

## Funktioner

* **Konton** – visar konto-ID och aktuellt saldo.
* **Insättning & Uttag** – användaren kan ändra saldot på ett specifikt konto. Ogiltiga eller negativa värden nekas.
* **Överföringar** – pengar kan skickas mellan två konton i banken. Systemet kontrollerar att avsändaren har tillräckligt saldo.
* **Transaktionshistorik** – visar de senaste transaktionerna för ett valt konto.

## Arkitektur

Lösningen består av två huvuddelar:

* **API (Server)** – ansvarar för databasoperationer, logik och att exponera endpoints (kan testas via Swagger).
* **Klient (Blazor)** – kommunicerar med API\:t via HTTP och visar datan i webbläsaren.

Projekten körs separat men kommunicerar via HTTP. Detta följer principen för **headless arkitektur**, där API\:t fungerar fristående men används av klienten.

## Validering av indata

För att undvika fel och göra systemet stabilare:

* Insättning och uttag av 0 eller negativa belopp tillåts inte.
* Överföringar kräver både avsändarens och mottagarens konto-ID, samt att saldot kontrolleras innan genomförande.
* Om ett konto inte finns returnerar API\:t ett felmeddelande istället för att krascha.

## Begränsningar och framtida förbättringar

* Det finns ingen tydlig uppdelning mellan kund- och administratörsroller, vilket påverkar säkerheten.
* Klientens design är enkel och kan förbättras med bättre gränssnitt.
* På sikt kan autentisering och mer detaljerad kontoinformation läggas till.

