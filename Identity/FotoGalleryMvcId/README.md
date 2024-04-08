- Comando creazione progetto **mvc** con autenticazione:

```c#
dotnet new mvc --auth Individual -o MvcAuthApp

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package microsoft.EntityFramework.Sqlite
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools 
``` 

- Aggiungi al Models un file AppUser

- Modifica l'ApplicationDbContext

- Migrazione ed aggiornamento del database 

```c#
dotnet new mvc --auth Individual -o MvcAuthApp

dotnet ef migrations add AggiungiFornitori --context ApplicationDbContext
dotnet ef database update --context ApplicationDbContext
``` 