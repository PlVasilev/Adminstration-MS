using System.Reflection;
using Administration.Server.Data.Models;
using Administration.Server.Features.Contracts.Models;
using Administration.Server.Infrastructure.Mapping;

namespace Administration.Server
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Infrastructure;
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;
        
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDatabase(Configuration)
                .AddIdentity()
                .AddJwtAuthentication(services.GetAppSettings(Configuration))
                .AddApplicationServices()
                .AddControllers(options =>
                    options.Filters.Add<ModelOrNotFoundActionFilter>());

            services.AddSwagger();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ContractServiceModel).GetTypeInfo().Assembly);
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app
                .AddSwaggerUI()
                .UseRouting()
                .UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); })
                .ApplyMigrations()
                .ApplyRoles();
               

        }
    }
}
