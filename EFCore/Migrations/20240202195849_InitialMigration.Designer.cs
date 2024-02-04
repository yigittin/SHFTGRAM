﻿// <auto-generated />
using System;
using EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240202195849_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFCore.DbModels.Follow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("FollowerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Follows");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FollowerId = new Guid("3db611ca-9ede-4497-b256-b83edd51b647"),
                            FollowingId = new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f")
                        },
                        new
                        {
                            Id = 2,
                            FollowerId = new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f"),
                            FollowingId = new Guid("3db611ca-9ede-4497-b256-b83edd51b647")
                        });
                });

            modelBuilder.Entity("EFCore.DbModels.Likes", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("EFCore.DbModels.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateTime = new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9724),
                            CreatedBy = "seeder",
                            IsDeleted = false,
                            LikeCount = 0,
                            ModifiedBy = "seeder",
                            ModifiedTime = new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9726),
                            Text = "SHFTGRAM IS ONLINE",
                            UserId = new Guid("3db611ca-9ede-4497-b256-b83edd51b647")
                        },
                        new
                        {
                            Id = 2,
                            CreateTime = new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9727),
                            CreatedBy = "seeder",
                            IsDeleted = false,
                            LikeCount = 0,
                            ModifiedBy = "seeder",
                            ModifiedTime = new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9728),
                            Text = "FEEL FREE TO EXPLORE",
                            UserId = new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f")
                        });
                });

            modelBuilder.Entity("EFCore.DbModels.RoleActionType", b =>
                {
                    b.Property<int>("RoleActionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleActionTypeId"), 1L, 1);

                    b.Property<Guid>("RoleTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserActionTypeId")
                        .HasColumnType("int");

                    b.HasKey("RoleActionTypeId");

                    b.HasIndex("RoleTypeId");

                    b.HasIndex("UserActionTypeId");

                    b.ToTable("RoleActionTypes");

                    b.HasData(
                        new
                        {
                            RoleActionTypeId = 1,
                            RoleTypeId = new Guid("567ceb59-3058-40ed-8999-f095202939c8"),
                            UserActionTypeId = 1
                        });
                });

            modelBuilder.Entity("EFCore.DbModels.RoleType", b =>
                {
                    b.Property<Guid>("RoleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsListed")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleNameLowered")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleTypeId");

                    b.ToTable("RoleTypes");

                    b.HasData(
                        new
                        {
                            RoleTypeId = new Guid("567ceb59-3058-40ed-8999-f095202939c8"),
                            IsListed = true,
                            RoleName = "User",
                            RoleNameLowered = "user"
                        });
                });

            modelBuilder.Entity("EFCore.DbModels.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BioText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ConfirmationGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FollowerCount")
                        .HasColumnType("int");

                    b.Property<int>("FollowingCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastActivateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastPasswordResetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WrongPasswordCount")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("3db611ca-9ede-4497-b256-b83edd51b647"),
                            ConfirmationGuid = new Guid("00000000-0000-0000-0000-000000000000"),
                            Email = "i.yigittin@hotmail.com",
                            FollowerCount = 1,
                            FollowingCount = 1,
                            IsConfirmed = true,
                            IsDeleted = false,
                            IsLocked = false,
                            LastActivateDate = new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9693),
                            LastLogin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastPasswordResetDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "İbrahim Yiğit",
                            Password = "+XLIphBpHWTKXJL0co5lySTbhS0=",
                            Phone = "5395954339",
                            RegisterDate = new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9702),
                            RoleId = new Guid("567ceb59-3058-40ed-8999-f095202939c8"),
                            Surname = "Tın",
                            UserName = "i.yigittin@hotmail.com",
                            WrongPasswordCount = 0
                        },
                        new
                        {
                            UserId = new Guid("139b96e3-7a21-4420-a391-c7ffb146b42f"),
                            ConfirmationGuid = new Guid("00000000-0000-0000-0000-000000000000"),
                            Email = "test@test",
                            FollowerCount = 1,
                            FollowingCount = 1,
                            IsConfirmed = true,
                            IsDeleted = false,
                            IsLocked = false,
                            LastActivateDate = new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9709),
                            LastLogin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastPasswordResetDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Test User",
                            Password = "+XLIphBpHWTKXJL0co5lySTbhS0=",
                            Phone = "5395954339",
                            RegisterDate = new DateTime(2024, 2, 2, 22, 58, 48, 999, DateTimeKind.Local).AddTicks(9710),
                            RoleId = new Guid("567ceb59-3058-40ed-8999-f095202939c8"),
                            Surname = "Shft",
                            UserName = "test@test",
                            WrongPasswordCount = 0
                        });
                });

            modelBuilder.Entity("EFCore.DbModels.UserActionType", b =>
                {
                    b.Property<int>("UserActionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserActionTypeId"), 1L, 1);

                    b.Property<string>("ActionCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserActionTypeId");

                    b.ToTable("UserActionTypes");

                    b.HasData(
                        new
                        {
                            UserActionTypeId = 1,
                            ActionCategory = "dashboard",
                            ActionName = "Anasayfa",
                            Type = "Dashboard"
                        });
                });

            modelBuilder.Entity("SHFTGRAMAPP.EFCore.DbModels.UploadedFiles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtention")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OldFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("EFCore.DbModels.Post", b =>
                {
                    b.HasOne("EFCore.DbModels.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFCore.DbModels.RoleActionType", b =>
                {
                    b.HasOne("EFCore.DbModels.RoleType", "RoleType")
                        .WithMany()
                        .HasForeignKey("RoleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.DbModels.UserActionType", "UserActionType")
                        .WithMany()
                        .HasForeignKey("UserActionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleType");

                    b.Navigation("UserActionType");
                });

            modelBuilder.Entity("EFCore.DbModels.User", b =>
                {
                    b.HasOne("EFCore.DbModels.RoleType", "RoleType")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleType");
                });

            modelBuilder.Entity("EFCore.DbModels.User", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}