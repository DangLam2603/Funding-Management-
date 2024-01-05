﻿// <auto-generated />
using System;
using FundingApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FundingApplication.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240104165803_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FundingApplication.Models.MonthSalary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<Guid?>("SalaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("dateOfTransaction")
                        .HasColumnType("datetime2");

                    b.Property<int>("month")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalaryId");

                    b.ToTable("monthSalaries");
                });

            modelBuilder.Entity("FundingApplication.Models.Salary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("salaries");
                });

            modelBuilder.Entity("FundingApplication.Models.Spending", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid?>("SalaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("SalaryId");

                    b.ToTable("spending");
                });

            modelBuilder.Entity("FundingApplication.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("FundingApplication.Models.MonthSalary", b =>
                {
                    b.HasOne("FundingApplication.Models.Salary", null)
                        .WithMany("monthSalaries")
                        .HasForeignKey("SalaryId");
                });

            modelBuilder.Entity("FundingApplication.Models.Salary", b =>
                {
                    b.HasOne("FundingApplication.Models.User", null)
                        .WithMany("salaries")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FundingApplication.Models.Spending", b =>
                {
                    b.HasOne("FundingApplication.Models.Salary", null)
                        .WithMany("Spendings")
                        .HasForeignKey("SalaryId");
                });

            modelBuilder.Entity("FundingApplication.Models.Salary", b =>
                {
                    b.Navigation("Spendings");

                    b.Navigation("monthSalaries");
                });

            modelBuilder.Entity("FundingApplication.Models.User", b =>
                {
                    b.Navigation("salaries");
                });
#pragma warning restore 612, 618
        }
    }
}