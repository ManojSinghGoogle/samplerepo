using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Data 
{
    public class MyDatabaseContext : DbContext
    {
    public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
           : base(options)
    {
    }

    public DbSet<Models.Todo> Todo { get; set; }
}
}
