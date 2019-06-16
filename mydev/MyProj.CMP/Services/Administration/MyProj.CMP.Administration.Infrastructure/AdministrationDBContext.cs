using Microsoft.EntityFrameworkCore;
using MyProj.CMP.Administration.Domain.Entities;
using MyProj.CMP.Administration.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Administration.Infrastructure
{
    public class AdministrationDBContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "administration";
        public AdministrationDBContext(DbContextOptions<AdministrationDBContext> options) : base(options) { }
        //public AdministrationDBContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ClientTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RetailClientConfiguration());
        }
        internal DbSet<Account> Accounts { get; set; }
        internal DbSet<Client> Clients { get; set; }
        internal DbSet<ClientType> ClientTypes { get; set; }
        internal DbSet<RetailClient> RetailClients { get; set; }

    }
}
