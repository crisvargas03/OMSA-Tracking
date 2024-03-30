﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OMSATrackingAPI.DAL.Data;

#nullable disable

namespace OMSATrackingAPI.DAL.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeOnly>("EstimatedArrivalHour")
                        .HasColumnType("time without time zone");

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

                    b.ToTable("Bus");
                });

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

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

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.FavoriteRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

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

                    b.ToTable("FavoriteRoute");
                });

            modelBuilder.Entity("OMSATrackingAPI.DAL.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

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
