using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_managment.Data;

namespace test_managment
{
    public static class SeedData
    {
        public static void Seed(UserManager<Patient> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<Patient> userManager)
        {
            if(userManager.FindByNameAsync("admin@gmail.com").Result == null)
            {
                var user = new Patient
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                };
                var result = userManager.CreateAsync(user, "P@ssword1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Patient").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Patient"
                };
               var result =  roleManager.CreateAsync(role).Result;
            }
        }

    }
}
