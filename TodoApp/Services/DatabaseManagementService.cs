using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Data;

namespace TodoApp.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationIntializatiion(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<MyDatabaseContext>().Database.Migrate();
            }
        }

    }
}
