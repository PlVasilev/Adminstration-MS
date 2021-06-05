﻿namespace Administration.Server.Infrastructure
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
        

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();
            var dBContext =  services.ServiceProvider.GetService<AdministrationDbContext>();
            
            dBContext.Database.Migrate();
        }
    }
}
