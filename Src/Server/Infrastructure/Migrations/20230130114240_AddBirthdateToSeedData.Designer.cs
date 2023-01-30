﻿// <auto-generated />
using System;
using Mc2.CrudTest.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mc2.CrudTest.Infrastructure.Migrations
{
    [DbContext(typeof(CrudTestReadWriteContext))]
    [Migration("20230130114240_AddBirthdateToSeedData")]
    partial class AddBirthdateToSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mc2.CrudTest.Domain.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BankAccountNumber")
                        .HasMaxLength(34)
                        .HasColumnType("VARCHAR");

                    b.Property<DateTimeOffset?>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasMaxLength(320)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Firstname")
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Lastname")
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(32)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("PhoneNumberCountryCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.HasIndex("Firstname", "Lastname", "DateOfBirth")
                        .IsUnique()
                        .HasFilter("[Firstname] IS NOT NULL AND [Lastname] IS NOT NULL AND [DateOfBirth] IS NOT NULL");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("09532446-967b-45e4-be15-013a4f03437e"),
                            BankAccountNumber = "1234123412341234",
                            DateOfBirth = new DateTimeOffset(new DateTime(2000, 6, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)),
                            Email = "Bahadori.meysam@outlook.com",
                            Firstname = "Meysam",
                            Lastname = "Bahadori",
                            PhoneNumber = "09397524270",
                            PhoneNumberCountryCode = "IR"
                        },
                        new
                        {
                            Id = new Guid("e40156ae-992e-4fc1-a071-0bfacf8f427d"),
                            BankAccountNumber = "213421342134",
                            DateOfBirth = new DateTimeOffset(new DateTime(1986, 6, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)),
                            Email = "iman.nasr@gmail.com",
                            Firstname = "Iman",
                            Lastname = "Nasr",
                            PhoneNumber = "09111111111",
                            PhoneNumberCountryCode = "IR"
                        },
                        new
                        {
                            Id = new Guid("8bd6dfea-6784-4b02-97c7-6d69b47e332a"),
                            BankAccountNumber = "4123412341234123",
                            DateOfBirth = new DateTimeOffset(new DateTime(1991, 6, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)),
                            Email = "shirazi.donya@gmail.com",
                            Firstname = "Donya",
                            Lastname = "shirazi",
                            PhoneNumber = "09111111113",
                            PhoneNumberCountryCode = "IR"
                        },
                        new
                        {
                            Id = new Guid("85259efb-0ca9-41d8-8159-e85c8535184f"),
                            BankAccountNumber = "3124312431243124",
                            DateOfBirth = new DateTimeOffset(new DateTime(1988, 6, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)),
                            Email = "abdi.faranak@yahoo.com",
                            Firstname = "Faranak",
                            Lastname = "Abdi",
                            PhoneNumber = "09111111112",
                            PhoneNumberCountryCode = "IR"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
