﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230625053602_Exam")]
    partial class Exam
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.Entities.DepartmentEmployee", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fromdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Todate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("DepartmentId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("DepartmentEmployees");
                });

            modelBuilder.Entity("Domain.Entities.DepartmentManager", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("Fromdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("Todate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("DepartmentId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("DepartmentManagers");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Hiredate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Entities.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amout")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fromdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Todate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("Domain.Entities.DepartmentEmployee", b =>
                {
                    b.HasOne("Domain.Entities.Department", "Department")
                        .WithMany("DepartmentEmployees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("DepartmentEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Entities.DepartmentManager", b =>
                {
                    b.HasOne("Domain.Entities.Department", "Department")
                        .WithMany("DepartmentManagers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("DepartmentManagers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Entities.Salary", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("Salaries")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Entities.Department", b =>
                {
                    b.Navigation("DepartmentEmployees");

                    b.Navigation("DepartmentManagers");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Navigation("DepartmentEmployees");

                    b.Navigation("DepartmentManagers");

                    b.Navigation("Salaries");
                });
#pragma warning restore 612, 618
        }
    }
}
