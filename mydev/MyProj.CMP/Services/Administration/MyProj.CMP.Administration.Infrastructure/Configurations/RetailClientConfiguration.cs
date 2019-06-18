using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProj.CMP.Administration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Administration.Infrastructure.Configurations
{
    public class RetailClientConfiguration : IEntityTypeConfiguration<RetailClient>
    {
        public void Configure(EntityTypeBuilder<RetailClient> builder)
        {
            builder.ToTable("RetailClient", "Market");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ForSqlServerUseSequenceHiLo("pk1_RetailClient");
            builder.Property(n => n.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(n => n.Description).IsRequired(true).HasMaxLength(255);
            builder.Property(n => n.MarketSiteCode).IsRequired(true).HasMaxLength(20);

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var commandlineArgs = Environment.GetCommandLineArgs();

            builder.HasData(
                    new RetailClient { Id = 1, Name = "TescoUK", Description = "Tesco UK", MarketSiteCode = "Tesco_UK" }
                    , new RetailClient { Id = 2, Name = "ExitoCO", Description = "Exito Colombia", MarketSiteCode = "CCO" }
                );
        }
    }
}
