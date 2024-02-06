﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaparaBootcampFinalHomework;

#nullable disable

namespace PaparaBootcampFinalHomework.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240206191922_second")]
    partial class second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PaparaBootcampFinalHomework.Models.Apartments.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("BlockInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerTenant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("PaparaBootcampFinalHomework.Models.Payments.MonthlyExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ElectricityBill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExpenseMonth")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GasBill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<decimal>("WaterBill")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("MonthlyExpenses");
                });

            modelBuilder.Entity("PaparaBootcampFinalHomework.Models.Payments.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<string>("CardCash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PaparaBootcampFinalHomework.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<int>("ApartmentId1")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PaparaBootcampFinalHomework.Models.Payments.Payment", b =>
                {
                    b.HasOne("PaparaBootcampFinalHomework.Models.Apartments.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaparaBootcampFinalHomework.Models.Apartments.Apartment", null)
                        .WithMany("Payments")
                        .HasForeignKey("UserId");

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("PaparaBootcampFinalHomework.Models.Users.User", b =>
                {
                    b.HasOne("PaparaBootcampFinalHomework.Models.Apartments.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("PaparaBootcampFinalHomework.Models.Apartments.Apartment", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
