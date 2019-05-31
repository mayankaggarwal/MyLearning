using dh.Media.CMP.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ForSqlServerUseSequenceHiLo("pk1_Account");
            builder.Property(n => n.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(n => n.Email).IsRequired(true).HasMaxLength(255);
            builder.HasIndex(u => u.Name).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var commandlineArgs = Environment.GetCommandLineArgs();
            Console.WriteLine(env);
            Console.WriteLine(string.Join(" ", commandlineArgs));

            builder.HasData(
                new Account { Id = 1, Name = "mayankgg", Email = "mayankgg@dunnhumby.com" }
                , new Account { Id = 2, Name = "system", Email = "system@dunnhumby.com" }
            );

            builder.HasData(
                new Account { Id = 3, Name = "mayankgg1", Email = "mayankgg1@dunnhumby.com" }
                , new Account { Id = 4, Name = "system1", Email = "system1@dunnhumby.com" }
            );


        }
    }
}
