﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebParking.Data.Data;

#nullable disable

namespace WebParking.Data.Migrations
{
    [DbContext(typeof(ParkingContext))]
    partial class ParkingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("IdentityRole");
                });

            modelBuilder.Entity("WebParking.Data.Entities.LotEntityModel", b =>
                {
                    b.Property<int>("LotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("lot_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LotId"));

                    b.Property<int>("IdParks")
                        .HasColumnType("integer")
                        .HasColumnName("id_parkings");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean")
                        .HasColumnName("is_bloked");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("boolean")
                        .HasColumnName("is_booked");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("ParksParkId")
                        .HasColumnType("integer");

                    b.HasKey("LotId");

                    b.HasIndex("ParksParkId");

                    b.ToTable("Lots");
                });

            modelBuilder.Entity("WebParking.Data.Entities.ParkingEntityModel", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("parking_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ParkId"));

                    b.Property<string>("Adress")
                        .HasColumnType("text")
                        .HasColumnName("adress");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ParkId");

                    b.ToTable("Parkings");
                });

            modelBuilder.Entity("WebParking.Data.Entities.UserEntityModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebParking.Data.Entities.UserLotEntityModel", b =>
                {
                    b.Property<int>("UserLotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_lot_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserLotId"));

                    b.Property<DateTime?>("BookedTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("booked_at");

                    b.Property<int>("IdLots")
                        .HasColumnType("integer")
                        .HasColumnName("id_lots");

                    b.Property<int>("IdUsers")
                        .HasColumnType("integer")
                        .HasColumnName("is_users");

                    b.Property<int>("LotsLotId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("integer");

                    b.HasKey("UserLotId");

                    b.HasIndex("LotsLotId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("UserLots");
                });

            modelBuilder.Entity("WebParking.Data.Entities.LotEntityModel", b =>
                {
                    b.HasOne("WebParking.Data.Entities.ParkingEntityModel", "Parks")
                        .WithMany()
                        .HasForeignKey("ParksParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parks");
                });

            modelBuilder.Entity("WebParking.Data.Entities.UserEntityModel", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebParking.Data.Entities.UserLotEntityModel", b =>
                {
                    b.HasOne("WebParking.Data.Entities.LotEntityModel", "Lots")
                        .WithMany()
                        .HasForeignKey("LotsLotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebParking.Data.Entities.UserEntityModel", "Users")
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lots");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
