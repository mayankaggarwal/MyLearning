using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProj.CMP.Administration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CMP.Administration.Infrastructure.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ForSqlServerUseSequenceHiLo("pk1_Client");
            builder.Property(n => n.Name).IsRequired(true).HasMaxLength(50).HasColumnType("nvarchar");
            builder.Property(n => n.Description).HasMaxLength(255);
            builder.Property(n => n.ClientTypeId).IsRequired(true);
            builder.HasOne(n => n.ClientType).WithMany(a => a.Clients).HasForeignKey(f => f.ClientTypeId);
            builder.HasOne(n => n.RetailClient).WithMany(a => a.Clients).HasForeignKey(f => f.RetailClientId);
            builder.HasOne(n => n.CreatedBy).WithMany(a => a.Clients).HasForeignKey(f => f.CreatedByUserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(n => n.UpdatedBy).WithMany().HasForeignKey(f => f.UpdatedByUserId).OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasData(
                new Client { Id = 1, Name = "Tesco UK", Description = "Tesco UK", ClientTypeId = 1, RetailClientId = 1, CreatedByUserId = 1 }
                , new Client { Id = 2, Name = "Dunnhumby", Description = "Tesco UK", ClientTypeId = 2, RetailClientId = 1, CreatedByUserId = 1 }
                , new Client { Id = 3, Name = "Exio CO", Description = "Exito CO", ClientTypeId = 1, RetailClientId = 2, CreatedByUserId = 1 }
                , new Client { Id = 4, Name = "Dunnhumby", Description = "Exito CO", ClientTypeId = 2, RetailClientId = 2, CreatedByUserId = 1 }
            );
        }
    }
}
