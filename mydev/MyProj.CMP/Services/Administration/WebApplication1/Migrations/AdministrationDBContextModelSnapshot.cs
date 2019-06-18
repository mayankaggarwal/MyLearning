﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyProj.CMP.Administration.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AdministrationDBContext))]
    partial class AdministrationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("Relational:Sequence:.pk1_Account", "'pk1_Account', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.pk1_Client", "'pk1_Client', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.pk1_ClientType", "'pk1_ClientType', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.pk1_RetailClient", "'pk1_RetailClient', '', '1', '10', '', '', 'Int64', 'False'");

            modelBuilder.Entity("MyProj.CMP.Administration.Domain.Entities.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "pk1_Account")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Account","administration");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Email = "mayankgg@dunnhumby.com",
                            Name = "mayankgg"
                        },
                        new
                        {
                            Id = 2L,
                            Email = "system@dunnhumby.com",
                            Name = "system"
                        });
                });

            modelBuilder.Entity("MyProj.CMP.Administration.Domain.Entities.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "pk1_Client")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<long>("ClientTypeId");

                    b.Property<long>("CreatedByUserId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Group");

                    b.Property<bool>("IsArchived");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long?>("RetailClientId");

                    b.Property<long>("UpdatedByUserId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ClientTypeId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("RetailClientId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("Client","administration");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ClientTypeId = 1L,
                            CreatedByUserId = 1L,
                            Description = "Tesco UK",
                            IsArchived = false,
                            Name = "Tesco UK",
                            RetailClientId = 1L,
                            UpdatedByUserId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            ClientTypeId = 2L,
                            CreatedByUserId = 1L,
                            Description = "Tesco UK",
                            IsArchived = false,
                            Name = "Dunnhumby",
                            RetailClientId = 1L,
                            UpdatedByUserId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            ClientTypeId = 1L,
                            CreatedByUserId = 1L,
                            Description = "Exito CO",
                            IsArchived = false,
                            Name = "Exio CO",
                            RetailClientId = 2L,
                            UpdatedByUserId = 1L
                        },
                        new
                        {
                            Id = 4L,
                            ClientTypeId = 2L,
                            CreatedByUserId = 1L,
                            Description = "Exito CO",
                            IsArchived = false,
                            Name = "Dunnhumby",
                            RetailClientId = 2L,
                            UpdatedByUserId = 1L
                        });
                });

            modelBuilder.Entity("MyProj.CMP.Administration.Domain.Entities.ClientType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "pk1_ClientType")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("ClientType","administration");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Retailer"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Dunnhumby"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Supplier"
                        });
                });

            modelBuilder.Entity("MyProj.CMP.Administration.Domain.Entities.RetailClient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "pk1_RetailClient")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("MarketSiteCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("RetailClient","Market");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Tesco UK",
                            MarketSiteCode = "Tesco_UK",
                            Name = "TescoUK"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Exito Colombia",
                            MarketSiteCode = "CCO",
                            Name = "ExitoCO"
                        });
                });

            modelBuilder.Entity("MyProj.CMP.Administration.Domain.Entities.Client", b =>
                {
                    b.HasOne("MyProj.CMP.Administration.Domain.Entities.ClientType", "ClientType")
                        .WithMany("Clients")
                        .HasForeignKey("ClientTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyProj.CMP.Administration.Domain.Entities.Account", "CreatedBy")
                        .WithMany("Clients")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyProj.CMP.Administration.Domain.Entities.RetailClient", "RetailClient")
                        .WithMany("Clients")
                        .HasForeignKey("RetailClientId");

                    b.HasOne("MyProj.CMP.Administration.Domain.Entities.Account", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
