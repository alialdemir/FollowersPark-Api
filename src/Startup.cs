using AutoMapper;
using FollowersPark.DataAccess;
using FollowersPark.DataAccess.EntityFramework.Context;
using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.DataAccess.Mapper;
using FollowersPark.DataAccess.Tables.Entity;
using FollowersPark.Extensions;
using FollowersPark.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace FollowersPark
{
    public partial class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            AddCors(app);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration);

            services.AddDbContext<FollowersParkContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();

            AuthConfigureServices(services);

            AddCorsConfigure(services);

            #region IOC

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbContextFactory>((service) =>
            {
                FollowersParkContext dbContext = service
                                                        .CreateScope()
                                                        .ServiceProvider
                                                        .GetRequiredService<FollowersParkContext>();

                return new DbContextFactory(dbContext);
            });

            services.AddScopedDynamic<IRepositoryBase<EntityBase>>();

            #endregion IOC

            services.AddAutoMapper(typeof(MappingProfile).GetTypeInfo().Assembly);

            var mvcBuilder = services.AddControllers();

            AddJsonOptions(mvcBuilder);
        }
    }
}