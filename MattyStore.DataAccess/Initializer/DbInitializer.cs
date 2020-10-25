using MattyStoreApp.DataAccess.Data;
using MattyStoreApp.Models;
using MattyStoreApp.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MattyStoreApp.DataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager )
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public void Initialize()
        {

            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {

                    _db.Database.Migrate();
                }

            }
            catch (Exception ex)
            { 
            
            }

            if (_db.Roles.Any(r => r.Name == SD.Role_Admin)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Comp)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Indi)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser {
               UserName = "onibuzz102@gmail.com",
               Email = "onibuzz102@gmail.com",
               EmailConfirmed = true,
               Name = "Olasunkanmi Onibonoje"


            }, "Admin123*").GetAwaiter().GetResult();

            ApplicationUser user = _db.ApplicationUsers.Where(x => x.Email == "onibuzz102@gmail.com").FirstOrDefault();


            _userManager.AddToRoleAsync(user, SD.Role_Admin);
        }



    }
}
