using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Administration.Server.Infrastructure
{
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddSwaggerUI(this IApplicationBuilder app) =>
            app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("swagger/v1/swagger.json", "My Administration API");
                    c.RoutePrefix = string.Empty;
                });
        

        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();
            var dBContext =  services.ServiceProvider.GetService<AdministrationDbContext>();
            
            dBContext.Database.Migrate();

            return app;
        }

        public static void ApplyRoles(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();
            var context = services.ServiceProvider.GetRequiredService<AdministrationDbContext>();

            if (context.Roles.Count() <= 1)
            {
                context.Roles.Add(new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" });
                context.Roles.Add(new IdentityRole() { Name = "User", NormalizedName = "USER" });
                context.Roles.Add(new IdentityRole() { Name = "Guest", NormalizedName = "GUEST" });
                context.SaveChanges();
            }
        }
    }
}
