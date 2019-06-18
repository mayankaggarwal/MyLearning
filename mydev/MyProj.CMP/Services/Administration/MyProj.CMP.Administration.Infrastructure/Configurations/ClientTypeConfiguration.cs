using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProj.CMP.Administration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Administration.Infrastructure.Configurations
{
    public class ClientTypeConfiguration : IEntityTypeConfiguration<ClientType>
    {
        public void Configure(EntityTypeBuilder<ClientType> builder)
        {
            builder.ToTable("ClientType", AdministrationDBContext.DEFAULT_SCHEMA);
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ForSqlServerUseSequenceHiLo("pk1_ClientType");
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(255).IsUnicode(true);

            builder.HasData(
                new ClientType { Id = 1, Name = "Retailer" }
                , new ClientType { Id = 2, Name = "Dunnhumby" }
                , new ClientType { Id = 3, Name = "Supplier" }
            );
        }
    }
}
