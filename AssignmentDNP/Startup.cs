using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AssignmentDNP.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AssignmentDNP.Data;
using AssignmentDNP.Persistence;
using Microsoft.AspNetCore.Components.Authorization;
using Persistence;

namespace AssignmentDNP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            
            services.AddHttpContextAccessor();
            services.AddScoped<IUserService, UsersCloud>();
            services.AddScoped<IPersonService, PeopleCloud>();
            
            services.AddScoped<AuthenticationStateProvider, UserCustomAuthenticationStateProvider>();
            /*services.AddScoped<AuthenticationStateProvider, PersonCustomAuthenticationStateProvider>();*/


            services.AddAuthorization(options =>
                {
                    options.AddPolicy("LoggedUser", policy =>
                        policy.RequireAuthenticatedUser().RequireAssertion(context =>
                        {
                            Claim logClaim = context.User.FindFirst(claim => claim.Type.Equals("ID"));
                            if (logClaim == null) return false;
                            return int.Parse(logClaim.Value)>0;
                        }));
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}