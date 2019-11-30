using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MST.IDP.Admin.Configuration.Constants;
using MST.IDP.Admin.Configuration.Identity;
using MST.IDP.Admin.Configuration.IdentityServer;
using MST.IDP.Admin.Configuration.Interfaces;
using Skoruba.IdentityServer4.Admin.EntityFramework.Interfaces;

namespace MST.IDP.Admin.Helpers
{
    public static class DbMigrationHelpers
    {
        /// <summary>
        /// Generate migrations before running this method, you can use these steps bellow:
        /// https://github.com/skoruba/IdentityServer4.Admin#ef-core--data-access
        /// </summary>
        /// <param name="host"></param>      
        public static async Task EnsureSeedData<TIdentityServerDbContext, TIdentityDbContext, TPersistedGrantDbContext, TLogDbContext, TUser, TRole>(IWebHost host)
            where TIdentityServerDbContext : DbContext, IAdminConfigurationDbContext
            where TIdentityDbContext : DbContext
            where TPersistedGrantDbContext : DbContext, IAdminPersistedGrantDbContext
            where TLogDbContext : DbContext, IAdminLogDbContext
            where TUser : IdentityUser, new()
            where TRole : IdentityRole, new()
        {
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                await EnsureDatabasesMigrated<TIdentityDbContext, TIdentityServerDbContext, TPersistedGrantDbContext, TLogDbContext>(services);
                await EnsureSeedData<TIdentityServerDbContext, TUser, TRole>(services);
            }
        }

        public static async Task EnsureDatabasesMigrated<TIdentityDbContext, TConfigurationDbContext, TPersistedGrantDbContext, TLogDbContext>(IServiceProvider services)
            where TIdentityDbContext : DbContext
            where TPersistedGrantDbContext : DbContext
            where TConfigurationDbContext : DbContext
            where TLogDbContext : DbContext
        {


            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<TPersistedGrantDbContext>())
                {
                    //TODO: Only DEV purpose
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }

                using (var context = scope.ServiceProvider.GetRequiredService<TIdentityDbContext>())
                {
                    await context.Database.MigrateAsync();
                }

                using (var context = scope.ServiceProvider.GetRequiredService<TConfigurationDbContext>())
                {
                    await context.Database.MigrateAsync();
                }

                using (var context = scope.ServiceProvider.GetRequiredService<TLogDbContext>())
                {
                    await context.Database.MigrateAsync();
                }
            }
        }

        public static async Task EnsureSeedData<TIdentityServerDbContext, TUser, TRole>(IServiceProvider serviceProvider)
        where TIdentityServerDbContext : DbContext, IAdminConfigurationDbContext
        where TUser : IdentityUser, new()
        where TRole : IdentityRole, new()
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TIdentityServerDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<TUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<TRole>>();
                var rootConfiguration = scope.ServiceProvider.GetRequiredService<IRootConfiguration>();

                await EnsureSeedIdentityServerData(context, rootConfiguration.AdminConfiguration);
                await EnsureSeedIdentityData(userManager, roleManager);
            }
        }

        /// <summary>
        /// Generate default admin user / role
        /// </summary>
        private static async Task EnsureSeedIdentityData<TUser, TRole>(UserManager<TUser> userManager,
            RoleManager<TRole> roleManager)
            where TUser : IdentityUser, new()
            where TRole : IdentityRole, new()
        {
            // Create admin role
            if (!await roleManager.RoleExistsAsync(AuthorizationConsts.AdministrationRole))
            {
                var role = new TRole { Name = AuthorizationConsts.AdministrationRole };

                await roleManager.CreateAsync(role);
            }

            // Create admin user
            if (await userManager.FindByNameAsync(Users.AdminUserName) != null) return;

            var user = new TUser
            {
                UserName = Users.AdminUserName,
                Email = Users.AdminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, Users.AdminPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, AuthorizationConsts.AdministrationRole);
            }

            foreach (var testUser in Users.Get())
            {
                var identityUser = new TUser()
                {
                    Id = testUser.SubjectId,
                    UserName = testUser.Username,
                    Email = testUser.Claims.Where(s => s.Type == "email").Select(c => c.Value).FirstOrDefault(),
                    EmailConfirmed = true

                };

                await userManager.CreateAsync(identityUser, "Password123!");
                await userManager.AddClaimsAsync(identityUser, testUser.Claims.ToList());
            }
        }

        /// <summary>
        /// Generate default clients, identity and api resources
        /// </summary>
        private static async Task EnsureSeedIdentityServerData<TIdentityServerDbContext>(TIdentityServerDbContext context, IAdminConfiguration adminConfiguration)
            where TIdentityServerDbContext : DbContext, IAdminConfigurationDbContext
        {
            foreach (var client in Clients.GetAdminClient(adminConfiguration).ToList())
            {
                var existingClient = context.Clients
                    .Include(c => c.AllowedScopes)
                    .Where(c => c.ClientId == client.ClientId).SingleOrDefault(); ;
                if (existingClient == null)
                {
                    await context.Clients.AddAsync(client.ToEntity());
                }
                else
                {
                    //TODO: Update only when change were made
                    var updatedEntity = client.ToEntity();
                    updatedEntity.Id = existingClient.Id;
                    context.Entry(existingClient).CurrentValues.SetValues(updatedEntity);
                }
            }

            await context.SaveChangesAsync();


            if (!context.IdentityResources.Any())
            {
                var identityResources = ClientResources.GetIdentityResources().ToList();

                foreach (var resource in identityResources)
                {
                    await context.IdentityResources.AddAsync(resource.ToEntity());
                }

                await context.SaveChangesAsync();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in ClientResources.GetApiResources(adminConfiguration).ToList())
                {
                    await context.ApiResources.AddAsync(resource.ToEntity());
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
