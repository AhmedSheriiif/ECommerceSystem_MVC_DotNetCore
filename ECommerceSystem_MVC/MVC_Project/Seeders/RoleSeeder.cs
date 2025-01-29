using Microsoft.AspNetCore.Identity;

namespace MVC_Project.Seeders
{

    public class RoleSeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleSeeder(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            // Define the roles you want to seed
            string[] roleNames = { "Admin", "User", "Seller" };

            foreach (var roleName in roleNames)
            {
                // Check if the role already exists
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Create the role if it doesn't exist
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
