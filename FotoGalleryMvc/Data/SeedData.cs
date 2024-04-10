using FotoGalleryMvc.Data;
using Microsoft.AspNetCore.Identity; 

public class SeedData
{
	public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
	{
		// Creazione dei ruoli se non esistono
		string[] roleNames = { "Admin", "Moderatore", "User" };
		foreach (var roleName in roleNames)
		{
			if (!await roleManager.RoleExistsAsync(roleName))
			{
				await roleManager.CreateAsync(new IdentityRole(roleName));
			}
		}

		// Creazione dell'utente Admin se non esiste
		if (await userManager.FindByEmailAsync("admin@admin.com") == null)
	  {
		  var adminUser = new AppUser
		  {
			  UserName = "admin@admin.com",
			  Email = "admin@admin.com",
			  Nome = "Admin",
			  Cognome = "Admin",
			  EmailConfirmed = true, // Accettazione in automatico
              Stato = true  
          };
		  await userManager.CreateAsync(adminUser, "AdminPass1!");
		  await userManager.AddToRoleAsync(adminUser, "Admin");
	  }
	  
	  
	  
			  

		
	}
}