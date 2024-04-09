using Microsoft.AspNetCore.Identity;
public class SeedData
{
    public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        //creazione dei ruoli se non esistono
        string[] roleNames = { "Admin", "Fornitore", "Cliente"};
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        if (await userManager.FindByEmailAsync("fdfdf@∂fdf.com") == null)
        {
            var adminUser = new AppUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                Nome = "Admin",
                CodiceFornitore = "12345678", //genera un codice fornitore univoco per ogni fornitore
                EmailConfirmed = true //accettazione in
            };
            await userManager.CreateAsync(adminUser, "AdminPass1!");
		  await userManager.AddToRoleAsync(adminUser, "Admin");
        }
        else{
            var adminUser = await userManager.FindByEmailAsync("fdfdf@∂fdf.com");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }

}