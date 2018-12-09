﻿// <auto-generated />
using System;
using Advancedproject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Advancedproject.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Advancedproject.Models.Department", b =>
                {
                    b.Property<int>("Deptno")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dept_floor");

                    b.Property<string>("Dept_name");

                    b.HasKey("Deptno");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Advancedproject.Models.Doctor", b =>
                {
                    b.Property<int>("Did")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("D_address");

                    b.Property<int>("D_age");

                    b.Property<string>("D_name");

                    b.Property<int>("Dept_no");

                    b.Property<int?>("departementDeptno");

                    b.HasKey("Did");

                    b.HasIndex("departementDeptno");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Advancedproject.Models.Employee", b =>
                {
                    b.Property<int>("Eid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("D_id");

                    b.Property<string>("E_gender");

                    b.Property<int>("E_phone");

                    b.Property<decimal>("E_salary");

                    b.Property<int?>("doctorDid");

                    b.HasKey("Eid");

                    b.HasIndex("doctorDid");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Advancedproject.Models.Patient", b =>
                {
                    b.Property<int>("pid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("p_gender");

                    b.Property<string>("p_name");

                    b.HasKey("pid");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Advancedproject.Models.Patient_Department", b =>
                {
                    b.Property<int>("pid");

                    b.Property<int>("deptno");

                    b.HasKey("pid", "deptno");

                    b.HasIndex("deptno");

                    b.ToTable("Patient_Departments");
                });

            modelBuilder.Entity("Advancedproject.Models.Patient_Doctor", b =>
                {
                    b.Property<int>("pid");

                    b.Property<int>("Did");

                    b.HasKey("pid", "Did");

                    b.HasIndex("Did");

                    b.ToTable("Patient_Doctors");
                });

            modelBuilder.Entity("Advancedproject.Models.Room", b =>
                {
                    b.Property<int>("Rno")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("R_floor");

                    b.Property<int?>("departmentDeptno");

                    b.Property<int>("dept_no");

                    b.HasKey("Rno");

                    b.HasIndex("departmentDeptno");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Advancedproject.Models.Doctor", b =>
                {
                    b.HasOne("Advancedproject.Models.Department", "departement")
                        .WithMany("doctorlist")
                        .HasForeignKey("departementDeptno");
                });

            modelBuilder.Entity("Advancedproject.Models.Employee", b =>
                {
                    b.HasOne("Advancedproject.Models.Doctor", "doctor")
                        .WithMany("employeelist")
                        .HasForeignKey("doctorDid");
                });

            modelBuilder.Entity("Advancedproject.Models.Patient_Department", b =>
                {
                    b.HasOne("Advancedproject.Models.Department", "department")
                        .WithMany("patientlist")
                        .HasForeignKey("deptno")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Advancedproject.Models.Patient", "patient")
                        .WithMany("Departmentlist")
                        .HasForeignKey("pid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Advancedproject.Models.Patient_Doctor", b =>
                {
                    b.HasOne("Advancedproject.Models.Doctor", "doctor")
                        .WithMany("patientlist")
                        .HasForeignKey("Did")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Advancedproject.Models.Patient", "patient")
                        .WithMany("doctorlist")
                        .HasForeignKey("pid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Advancedproject.Models.Room", b =>
                {
                    b.HasOne("Advancedproject.Models.Department", "department")
                        .WithMany("roomlist")
                        .HasForeignKey("departmentDeptno");
                });
#pragma warning restore 612, 618
        }
    }
}
