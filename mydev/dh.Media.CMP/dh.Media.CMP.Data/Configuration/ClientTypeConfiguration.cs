using dh.Media.CMP.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Configuration
{
    public class ClientTypeConfiguration : IEntityTypeConfiguration<ClientType>
    {
        public void Configure(EntityTypeBuilder<ClientType> builder)
        {
            builder.ToTable("ClientType");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ForSqlServerUseSequenceHiLo("pk1_ClientType");
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(255).IsUnicode(true);

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine(env);
            builder.HasData(
                new ClientType { Id = 1, Name = "Retailer" }
                , new ClientType { Id = 2, Name = "Dunnhumby" }
                , new ClientType { Id = 3, Name = "Supplier" }
            );
        }
    }
}
