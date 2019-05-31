﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dh.Media.CMP.Data;

namespace dh.Media.CMP.Data.Migrations
{
    [DbContext(typeof(MediaDBContext))]
    [Migration("20190531040507_AddingClients")]
    partial class AddingClients
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.pk1_Account", "'pk1_Account', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.pk1_Client", "'pk1_Client', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.pk1_ClientType", "'pk1_ClientType', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.pk1_RetailClient", "'pk1_RetailClient', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dh.Media.CMP.Data.Entity.Account", b =>
                {
                    b.Property<int>("Id")
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

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "mayankgg@dunnhumby.com",
                            Name = "mayankgg"
                        },
                        new
                        {
                            Id = 2,
                            Email = "system@dunnhumby.com",
                            Name = "system"
                        },
                        new
                        {
                            Id = 3,
                            Email = "mayankgg1@dunnhumby.com",
                            Name = "mayankgg1"
                        },
                        new
                        {
                            Id = 4,
                            Email = "system1@dunnhumby.com",
                            Name = "system1"
                        });
                });

            modelBuilder.Entity("dh.Media.CMP.Data.Entity.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "pk1_Client")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("ClientTypeId");

                    b.Property<int>("CreatedByUserId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Group");

                    b.Property<bool>("IsArchived");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasMaxLength(50);

                    b.Property<int?>("RetailClientId");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ClientTypeId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("RetailClientId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("Client");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientTypeId = 1,
                            CreatedByUserId = 1,
                            Description = "Tesco UK",
                            IsArchived = false,
                            Name = "Tesco UK",
                            RetailClientId = 1,
                            UpdatedByUserId = 0
                        },
                        new
                        {
                            Id = 2,
                            ClientTypeId = 2,
                            CreatedByUserId = 1,
                            Description = "Tesco UK",
                            IsArchived = false,
                            Name = "Dunnhumby",
                            RetailClientId = 1,
                            UpdatedByUserId = 0
                        },
                        new
                        {
                            Id = 3,
                            ClientTypeId = 1,
                            CreatedByUserId = 1,
                            Description = "Exito CO",
                            IsArchived = false,
                            Name = "Exio CO",
                            RetailClientId = 2,
                            UpdatedByUserId = 0
                        },
                        new
                        {
                            Id = 4,
                            ClientTypeId = 2,
                            CreatedByUserId = 1,
                            Description = "Exito CO",
                            IsArchived = false,
                            Name = "Dunnhumby",
                            RetailClientId = 2,
                            UpdatedByUserId = 0
                        });
                });

            modelBuilder.Entity("dh.Media.CMP.Data.Entity.ClientType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "pk1_ClientType")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("ClientType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Retailer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dunnhumby"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Supplier"
                        });
                });

            modelBuilder.Entity("dh.Media.CMP.Data.Entity.RetailClient", b =>
                {
                    b.Property<int>("Id")
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

                    b.ToTable("RetailClient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Tesco UK",
                            MarketSiteCode = "Tesco_UK",
                            Name = "TescoUK"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Exito Colombia",
                            MarketSiteCode = "CCO",
                            Name = "ExitoCO"
                        });
                });

            modelBuilder.Entity("dh.Media.CMP.Data.Entity.Client", b =>
                {
                    b.HasOne("dh.Media.CMP.Data.Entity.ClientType", "ClientType")
                        .WithMany("Clients")
                        .HasForeignKey("ClientTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("dh.Media.CMP.Data.Entity.Account", "CreatedBy")
                        .WithMany("Clients")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("dh.Media.CMP.Data.Entity.RetailClient", "RetailClient")
                        .WithMany("Clients")
                        .HasForeignKey("RetailClientId");

                    b.HasOne("dh.Media.CMP.Data.Entity.Account", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
