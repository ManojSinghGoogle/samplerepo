using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;
using TodoApp.Data;
using TodoApp.Services;

namespace TodoApp
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
           /* var server = Configuration["DatabaseServer"] ?? "";
            var port = Configuration["DatabasePort"] ?? "";
            var user = Configuration["DatabaseUser"] ?? "";
            var password = Configuration["DatabasePassword"] ?? "";
            var database = Configuration["DatabaseName"] ?? "";*/
             
            //var connectionString = $"Server={server}, {port}; Initial Catalog={database}; User ID={user};Password={password}";

            var connectionString = @"Server=sql-server,1433;Database=master;User=sa;Password=Passw0rd2021@;";
            Console.WriteLine("connection string is : " + connectionString);
            services.AddControllersWithViews();
            services.AddDbContext<MyDatabaseContext>(options =>
                    //options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")));
                    options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DatabaseManagementService.MigrationIntializatiion(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //app.UseAuthorization();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            /*  app.UseMvc(routes =>
              {
                  routes.MapRoute(
                      name: "default",
                      template: "{controller=Home}/{action=Index}/{id?}");
              });*/
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Todos}/{action=Index}/{id?}");
            });
        }
    }
}
