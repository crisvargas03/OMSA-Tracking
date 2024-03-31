﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OMSATrackingAPI.DAL.Data;

#nullable disable

namespace OMSATrackingAPI.DAL.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20240331030803_EditTableName")]
    partial class EditTableName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 1001L, null, null, null, null, null);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            CreatedBy = "Admin",
                            CreationDate = new DateTime(2024, 3, 31, 3, 8, 3, 41, DateTimeKind.Utc).AddTicks(9959),
                            IsDeleted = false,
                            Password = "Api12345",
                            Username = "Api"
                        });
                });

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 1001L, null, null, null, null, null);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EstimatedArrivalHour")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("PassengerLimit")
                        .HasColumnType("integer");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Buses");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            CreatedBy = "Admin",
                            CreationDate = new DateTime(2024, 3, 31, 3, 8, 3, 43, DateTimeKind.Utc).AddTicks(5119),
                            EstimatedArrivalHour = "08:00",
                            IsDeleted = false,
                            Latitude = "18.486057",
                            Longitude = "-69.931212",
                            Name = "Bus 1",
                            PassengerLimit = 30,
                            Plate = "A123456",
                            RouteId = 1001
                        },
                        new
                        {
                            Id = 1002,
                            CreatedBy = "Admin",
                            CreationDate = new DateTime(2024, 3, 31, 3, 8, 3, 43, DateTimeKind.Utc).AddTicks(5125),
                            EstimatedArrivalHour = "08:00",
                            IsDeleted = false,
                            Latitude = "18.486057",
                            Longitude = "-69.931212",
                            Name = "Bus 2",
                            PassengerLimit = 30,
                            Plate = "B123456",
                            RouteId = 1002
                        });
                });

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 1001L, null, null, null, null, null);

                    b.Property<int>("BusId")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IndentificationDocument")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("BusId")
                        .IsUnique();

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            BusId = 1001,
                            CreatedBy = "Admin",
                            CreationDate = new DateTime(2024, 3, 31, 3, 8, 3, 44, DateTimeKind.Utc).AddTicks(3477),
                            IndentificationDocument = "123456789",
                            IsDeleted = false,
                            LastName = "Driver 1",
                            Name = "Driver 1"
                        },
                        new
                        {
                            Id = 1002,
                            BusId = 1002,
                            CreatedBy = "Admin",
                            CreationDate = new DateTime(2024, 3, 31, 3, 8, 3, 44, DateTimeKind.Utc).AddTicks(3480),
                            IndentificationDocument = "987654321",
                            IsDeleted = false,
                            LastName = "Driver 2",
                            Name = "Driver 2"
                        });
                });

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.FavoriteRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 1001L, null, null, null, null, null);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdBus")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserIdentificationCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdBus")
                        .IsUnique();

                    b.ToTable("FavoriteRoutes");
                });

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 1001L, null, null, null, null, null);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Route");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            Address = "Av. Maximo Gomez",
                            Code = "R001",
                            CreatedBy = "Admin",
                            CreationDate = new DateTime(2024, 3, 31, 3, 8, 3, 44, DateTimeKind.Utc).AddTicks(8493),
                            Destination = "Destino 1",
                            IsDeleted = false,
                            Name = "Ruta Principal",
                            Origin = "Origen 1"
                        },
                        new
                        {
                            Id = 1002,
                            Address = "Corredor John F. Kennedy",
                            Code = "R002",
                            CreatedBy = "Admin",
                            CreationDate = new DateTime(2024, 3, 31, 3, 8, 3, 44, DateTimeKind.Utc).AddTicks(8496),
                            Destination = "Destino 2",
                            IsDeleted = false,
                            Name = "Ruta Secundaria",
                            Origin = "Origen 2"
                        });
                });

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.Bus", b =>
                {
                    b.HasOne("OMSATrackingAPI.DAL.Models.Route", "Route")
                        .WithMany("Buses")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.Driver", b =>
                {
                    b.HasOne("OMSATrackingAPI.DAL.Models.Bus", "Bus")
                        .WithOne("Driver")
                        .HasForeignKey("OMSATrackingAPI.DAL.Models.Driver", "BusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.FavoriteRoute", b =>
                {
                    b.HasOne("OMSATrackingAPI.DAL.Models.Bus", "Bus")
                        .WithOne("FavoriteRoute")
                        .HasForeignKey("OMSATrackingAPI.DAL.Models.FavoriteRoute", "IdBus")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.Bus", b =>
                {
                    b.Navigation("Driver")
                        .IsRequired();

                    b.Navigation("FavoriteRoute")
                        .IsRequired();
                });

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.Route", b =>
                {
                    b.Navigation("Buses");
                });
#pragma warning restore 612, 618
        }
    }
}
