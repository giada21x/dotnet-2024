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


``` c#
@Model AppUser 
@{
    ViewData["Title"] = "Fornitore";

    var stato = Model.Stato ? Attivo : Disattivo;
    var colore = Model.Stato ? "green" : "red";
    var icona = Model.Stato ? "fa-check" : "fa-times";

    ViewData["Icona"] = icona;
    ViewData["Colore"] = colore;
    ViewData["Stato"] = stato;
}

<h1>@Model.Nome</h1>
<div class= "row">
<div class= "col-md-6">
<div class= "">
``` 