using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SignalR;

using Microsoft.EntityFrameworkCore;
using WebApplicatie.Hubs;

namespace WebApplicatie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ClientContext>(builder => builder.UseSqlite("Data Source=database.db"));
           
           var ConnectionString = Configuration.GetConnectionString("DefaultConnection");
           services.AddMvc();

            services.AddIdentity<Account, IdentityRole>(config => { 
            config.Password.RequiredLength = 1;
            config.Password.RequireDigit = false;  
            config.Password.RequireUppercase = false;
            config.Password.RequireNonAlphanumeric = false;
           })
            .AddEntityFrameworkStores<ClientContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config => {config.Cookie.Name = "account.cookie"; config.LoginPath = "/Home/Login"; }); 

            services.AddControllersWithViews();

            services.AddSignalR();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            // app.UseSignalR(routes => {
            //     routes.MapHub<ChatHub>("/chatHub");
            // });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<chatHub>("/chatHub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{id2?}/{id3?}");
            });
        }
    }
}
