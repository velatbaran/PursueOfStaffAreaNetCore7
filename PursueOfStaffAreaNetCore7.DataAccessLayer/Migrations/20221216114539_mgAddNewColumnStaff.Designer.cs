﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PursueOfStaffAreaNetCore7.DataAccessLayer.DataContext;

#nullable disable

namespace PursueOfStaffAreaNetCore7.DataAccessLayer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221216114539_mgAddNewColumnStaff")]
    partial class mgAddNewColumnStaff
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.AllowRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AllowTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HowManyDays")
                        .HasColumnType("int");

                    b.Property<bool>("IsAllowed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegisteringUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AllowTypeId");

                    b.HasIndex("StaffId");

                    b.HasIndex("UserId");

                    b.ToTable("AllowRequests");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.AllowType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegisteringUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AllowTypes");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegisteringUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Degree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegisteringUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegisteringUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Duty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegisteringUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dutys");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.DutyAssign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegisteringUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("WeekVacation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("StaffId");

                    b.ToTable("DutyAssigns");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.EducationState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegisteringUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EducationStates");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegisteringUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Profession");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DegreeId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DutyId")
                        .HasColumnType("int");

                    b.Property<int>("EducationStateId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ExitDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDutyAssigned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStateWorking")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("ProfessionId")
                        .HasColumnType("int");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegisteringUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RemainDay")
                        .HasColumnType("int");

                    b.Property<int>("StaffStatuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("TotalAllowDay")
                        .HasColumnType("int");

                    b.Property<int>("TotalWorkingYear")
                        .HasColumnType("int");

                    b.Property<int>("UsedDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DegreeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DutyId");

                    b.HasIndex("EducationStateId");

                    b.HasIndex("ProfessionId");

                    b.HasIndex("StaffStatuId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.StaffStatu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegisteringUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StaffStatus");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RePassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegisteringUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.AllowRequest", b =>
                {
                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.AllowType", "AllowType")
                        .WithMany()
                        .HasForeignKey("AllowTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Staff", "Staff")
                        .WithMany("AllowRequests")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.User", "User")
                        .WithMany("AllowRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AllowType");

                    b.Navigation("Staff");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Area", b =>
                {
                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Staff", "Staff")
                        .WithMany("Areas")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.DutyAssign", b =>
                {
                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Area", "Area")
                        .WithMany("DutyAssigns")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Staff", "Staff")
                        .WithMany("DutyAssigns")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Staff", b =>
                {
                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Degree", "Degree")
                        .WithMany("Staffs")
                        .HasForeignKey("DegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Department", "Department")
                        .WithMany("Staffs")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Duty", "Duty")
                        .WithMany("Staffs")
                        .HasForeignKey("DutyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.EducationState", "EducationState")
                        .WithMany("Staffs")
                        .HasForeignKey("EducationStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Profession", "Profession")
                        .WithMany("Staffs")
                        .HasForeignKey("ProfessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.StaffStatu", "StaffStatu")
                        .WithMany("Staffs")
                        .HasForeignKey("StaffStatuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Degree");

                    b.Navigation("Department");

                    b.Navigation("Duty");

                    b.Navigation("EducationState");

                    b.Navigation("Profession");

                    b.Navigation("StaffStatu");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.User", b =>
                {
                    b.HasOne("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Area", b =>
                {
                    b.Navigation("DutyAssigns");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Degree", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Department", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Duty", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.EducationState", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Profession", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.Staff", b =>
                {
                    b.Navigation("AllowRequests");

                    b.Navigation("Areas");

                    b.Navigation("DutyAssigns");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.StaffStatu", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("PursueOfStaffAreaNetCore7.EntityLayer.Entities.User", b =>
                {
                    b.Navigation("AllowRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
