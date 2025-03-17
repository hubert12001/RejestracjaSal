﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RejestracjaSal.Models;

#nullable disable

namespace RejestracjaSal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250317204157_Users table added")]
    partial class Userstableadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RejestracjaSal.Models.Users", b =>
                {
                    b.Property<int>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("Role_id")
                        .HasColumnType("int");

                    b.HasKey("User_id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            User_id = 1,
                            Email = "Admin@gmail.com",
                            Login = "Admin",
                            Name = "Admin",
                            Password = "Admin",
                            Phone = 698785383,
                            Role_id = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
