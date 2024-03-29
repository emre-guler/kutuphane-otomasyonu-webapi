﻿// <auto-generated />
using System;
using LibraryProjectBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryProjectBackend.Data.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20191214001248_M1")]
    partial class M1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryProjectBackend.Models.AdminAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tcId")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AdminAccounts");
                });

            modelBuilder.Entity("LibraryProjectBackend.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bookPage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("deleteState")
                        .HasColumnType("int");

                    b.Property<int>("lentState")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryProjectBackend.Models.BookUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("bookId")
                        .HasColumnType("int");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("giveBook")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("receiveBook")
                        .HasColumnType("datetime2");

                    b.Property<int>("state")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("BookUsers");
                });

            modelBuilder.Entity("LibraryProjectBackend.Models.UserAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("deleteState")
                        .HasColumnType("int");

                    b.Property<int>("tcId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("UserAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
