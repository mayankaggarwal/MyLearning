using dh.Media.CMP.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data.Configuration
{
    public class RetailClientEntityTypeConfiguration : IEntityTypeConfiguration<RetailClient>
    {
        public void Configure(EntityTypeBuilder<RetailClient> builder)
        {
            builder.ToTable("RetailClient");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ForSqlServerUseSequenceHiLo("pk1_RetailClient");
            builder.Property(n => n.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(n => n.Description).IsRequired(true).HasMaxLength(255);
            builder.Property(n => n.MarketSiteCode).IsRequired(true).HasMaxLength(20);

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var commandlineArgs = Environment.GetCommandLineArgs();

            builder.HasData(
                    new RetailClient { Id=1,Name="TescoUK",Description="Tesco UK",MarketSiteCode="Tesco_UK"}
                    , new RetailClient { Id = 2, Name = "ExitoCO",Description="Exito Colombia", MarketSiteCode = "CCO" }
                );
        }
    }
}
