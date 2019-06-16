using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyProj.CMP.Administration.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;

namespace MyProj.CMP.Administration.DBRunner
{
    //public class AdministrationDbContextFactory : IDesignTimeDbContextFactory<AdministrationDBContext>
    //{
    //    public AdministrationDBContext CreateDbContext(string[] args)
    //    {
    //        string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    //        IConfiguration config = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();
    //        var optionsBuilder = new DbContextOptionsBuilder<AdministrationDBContext>();
    //        var connectionString = config.GetConnectionString("DefaultConnection");
    //        Console.WriteLine("Connection String:" + connectionString);
    //        //var connectionString = "Server=DELL\\SQLEXPRESS;Database=Administration;Trusted_Connection=True;";
    //        optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(AdministrationDbContextFactory).GetTypeInfo().Assembly.GetName().Name));
    //        return new AdministrationDBContext(optionsBuilder.Options);
    //    }
    //}
}
