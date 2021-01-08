using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FollowersPark
{
    public partial class Startup
    {
        public void AddCors(IApplicationBuilder app)
        {
            app.UseCors();
        }

        public void AddCorsConfigure(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
               {
                   string clientDomain = Configuration.GetSection("ClientDomain").Value;
                   if (!string.IsNullOrEmpty(clientDomain))
                       builder = builder.WithOrigins(clientDomain);

                   builder
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials()
                      .SetIsOriginAllowed((host) => true);
               });
            });
        }
    }
}