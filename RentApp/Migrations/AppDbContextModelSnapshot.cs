﻿// <auto-generated />
using System;
using RentApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace RentApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("u1790493_1")
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RentApp.Data.Car", b =>
            {
                b.Property<decimal>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(20,0)");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                b.Property<bool>("Archive")
                    .HasColumnType("bit");

                b.Property<string>("Color")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Comment")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CreatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<decimal?>("PhotoId")
                    .HasColumnType("decimal(20,0)");

                b.Property<string>("PublicDescription")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PublicName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Rate")
                    .HasColumnType("nvarchar(max)");

                b.Property<decimal?>("SegmentId")
                    .HasColumnType("decimal(20,0)");

                b.Property<string>("UpdatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.HasIndex("PhotoId");

                b.HasIndex("SegmentId");

                b.ToTable("Cars", "u1790493_1");
            });

            modelBuilder.Entity("RentApp.Data.Contract", b =>
            {
                b.Property<decimal>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(20,0)");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                b.Property<decimal>("CarId")
                    .HasColumnType("decimal(20,0)");

                b.Property<string>("Comment")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CreatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<string>("Deposit")
                    .HasColumnType("nvarchar(max)");

                b.Property<decimal?>("DriverId")
                    .HasColumnType("decimal(20,0)");

                b.Property<bool>("Endless")
                    .HasColumnType("bit");

                b.Property<DateTime>("Finish")
                    .HasColumnType("datetime2");

                b.Property<bool>("Finished")
                    .HasColumnType("bit");

                b.Property<string>("Penalty")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("Start")
                    .HasColumnType("datetime2");

                b.Property<string>("UpdatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.HasIndex("CarId");

                b.HasIndex("DriverId");

                b.ToTable("Contracts", "u1790493_1");
            });

            modelBuilder.Entity("RentApp.Data.DistanceItem", b =>
            {
                b.Property<decimal>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(20,0)");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                b.Property<string>("Comment")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CreatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UpdatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.ToTable("Distances", "u1790493_1");

                b.HasData(
                    new
                    {
                        Id = 1m,
                        CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        Name = "Город",
                        UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                    },
                    new
                    {
                        Id = 2m,
                        CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        Name = "Город и область",
                        UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                    },
                    new
                    {
                        Id = 3m,
                        CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        Name = "За пределы области",
                        UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                    },
                    new
                    {
                        Id = 4m,
                        CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        Name = "Смешанная",
                        UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                    });
            });

            modelBuilder.Entity("RentApp.Data.Driver", b =>
            {
                b.Property<decimal>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(20,0)");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                b.Property<string>("Comment")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CreatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<int>("Debt")
                    .HasColumnType("int");

                b.Property<string>("FirstName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LastName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PhoneNumber")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UpdatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.ToTable("Drivers", "u1790493_1");
            });

            modelBuilder.Entity("RentApp.Data.Expense", b =>
            {
                b.Property<decimal>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(20,0)");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                b.Property<decimal>("CarId")
                    .HasColumnType("decimal(20,0)");

                b.Property<string>("Comment")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CreatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("Date")
                    .HasColumnType("date");

                b.Property<string>("UpdatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.Property<int>("Value")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("CarId");

                b.ToTable("Expenses", "u1790493_1");
            });

            modelBuilder.Entity("RentApp.Data.MainHistory", b =>
            {
                b.Property<decimal>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(20,0)");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                b.Property<decimal?>("CarId")
                    .HasColumnType("decimal(20,0)");

                b.Property<string>("Comment")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CreatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("Date")
                    .HasColumnType("date");

                b.Property<decimal>("MaintenanceId")
                    .HasColumnType("decimal(20,0)");

                b.Property<int>("Mileage")
                    .HasColumnType("int");

                b.Property<int>("Next")
                    .HasColumnType("int");

                b.Property<string>("UpdatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.HasIndex("CarId");

                b.HasIndex("MaintenanceId");

                b.ToTable("MainHistories", "u1790493_1");
            });

            modelBuilder.Entity("RentApp.Data.Maintenance", b =>
            {
                b.Property<decimal>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(20,0)");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                b.Property<decimal>("CarId")
                    .HasColumnType("decimal(20,0)");

                b.Property<string>("Comment")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CreatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<string>("Descr")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("MileageStep")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UpdatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.HasIndex("CarId");

                b.ToTable("Maintenances", "u1790493_1");
            });

            modelBuilder.Entity("RentApp.Data.Mileage", b =>
            {
                b.Property<decimal>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(20,0)");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                b.Property<decimal>("CarId")
                    .HasColumnType("decimal(20,0)");

                b.Property<string>("Comment")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CreatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("Date")
                    .HasColumnType("date");

                b.Property<string>("UpdatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.Property<int>("Value")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("CarId");

                b.ToTable("Mileages", "u1790493_1");
            });

            modelBuilder.Entity("RentApp.Data.Payment", b =>
            {
                b.Property<decimal>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(20,0)");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                b.Property<string>("Comment")
                    .HasColumnType("nvarchar(max)");

                b.Property<decimal>("ContractId")
                    .HasColumnType("decimal(20,0)");

                b.Property<string>("CreatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("Date")
                    .HasColumnType("date");

                b.Property<int>("Debt")
                    .HasColumnType("int");

                b.Property<int>("Income")
                    .HasColumnType("int");

                b.Property<string>("Paid")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PaymentDate")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PaymentType")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UpdatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.HasIndex("ContractId");

                b.ToTable("Payments", "u1790493_1");
            });

            modelBuilder.Entity("RentApp.Data.Photo", b =>
            {
                b.Property<decimal>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(20,0)");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                b.Property<string>("Comment")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CreatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<string>("UpdatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.Property<byte[]>("Value")
                    .IsRequired()
                    .HasColumnType("varbinary(max)");

                b.HasKey("Id");

                b.ToTable("Photos", "u1790493_1");
            });

            modelBuilder.Entity("RentApp.Data.Request", b =>
            {
                b.Property<decimal>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(20,0)");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                b.Property<decimal?>("CarId")
                    .HasColumnType("decimal(20,0)");

                b.Property<string>("Comment")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CreatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<decimal>("DistanceId")
                    .HasColumnType("decimal(20,0)");

                b.Property<DateTime>("Finish")
                    .HasColumnType("datetime2");

                b.Property<string>("PhoneNumber")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("Processed")
                    .HasColumnType("bit");

                b.Property<DateTime>("Start")
                    .HasColumnType("datetime2");

                b.Property<string>("UpdatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.HasIndex("CarId");

                b.HasIndex("DistanceId");

                b.ToTable("Requests", "u1790493_1");
            });

            modelBuilder.Entity("RentApp.Data.SegmentItem", b =>
            {
                b.Property<decimal>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("decimal(20,0)");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                b.Property<string>("Comment")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CreatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("CreatedDate")
                    .HasColumnType("datetime2");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UpdatedBy")
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("UpdatedDate")
                    .HasColumnType("datetime2");

                b.HasKey("Id");

                b.ToTable("Segments", "u1790493_1");

                b.HasData(
                    new
                    {
                        Id = 1m,
                        CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        Name = "Инвестор",
                        UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                    },
                    new
                    {
                        Id = 2m,
                        CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        Name = "ДемидовПарк",
                        UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                    },
                    new
                    {
                        Id = 3m,
                        CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        Name = "Премиум",
                        UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                    },
                    new
                    {
                        Id = 4m,
                        CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        Name = "Комфорт",
                        UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                    });
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
            {
                b.Property<string>("Id")
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                b.Property<string>("NormalizedName")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                b.HasKey("Id");

                b.HasIndex("NormalizedName")
                    .IsUnique()
                    .HasDatabaseName("RoleNameIndex")
                    .HasFilter("[NormalizedName] IS NOT NULL");

                b.ToTable("AspNetRoles", "u1790493_1");

                b.HasData(
                    new
                    {
                        Id = "33fbf4a6-31b3-4285-bbea-5929f98be3a3",
                        ConcurrencyStamp = "8753a9eb-c530-40c5-a935-b0a0c16b4a99",
                        Name = "admin",
                        NormalizedName = "ADMIN"
                    },
                    new
                    {
                        Id = "36888aa0-fddb-46e4-a016-a687b7d4d538",
                        ConcurrencyStamp = "e7182b07-5ee6-4e0b-82b6-249978678055",
                        Name = "manager",
                        NormalizedName = "MANAGER"
                    });
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                b.Property<string>("ClaimType")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ClaimValue")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("RoleId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.HasKey("Id");

                b.HasIndex("RoleId");

                b.ToTable("AspNetRoleClaims", "u1790493_1");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
            {
                b.Property<string>("Id")
                    .HasColumnType("nvarchar(450)");

                b.Property<int>("AccessFailedCount")
                    .HasColumnType("int");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Email")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                b.Property<bool>("EmailConfirmed")
                    .HasColumnType("bit");

                b.Property<bool>("LockoutEnabled")
                    .HasColumnType("bit");

                b.Property<DateTimeOffset?>("LockoutEnd")
                    .HasColumnType("datetimeoffset");

                b.Property<string>("NormalizedEmail")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                b.Property<string>("NormalizedUserName")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                b.Property<string>("PasswordHash")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PhoneNumber")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("PhoneNumberConfirmed")
                    .HasColumnType("bit");

                b.Property<string>("SecurityStamp")
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("TwoFactorEnabled")
                    .HasColumnType("bit");

                b.Property<string>("UserName")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                b.HasKey("Id");

                b.HasIndex("NormalizedEmail")
                    .HasDatabaseName("EmailIndex");

                b.HasIndex("NormalizedUserName")
                    .IsUnique()
                    .HasDatabaseName("UserNameIndex")
                    .HasFilter("[NormalizedUserName] IS NOT NULL");

                b.ToTable("AspNetUsers", "u1790493_1");

                b.HasData(
                    new
                    {
                        Id = "519774b7-dd1b-430a-8b25-eef507ca1091",
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "36a4865d-120a-4621-8c1f-6af7789d405b",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        NormalizedUserName = "DIRECTOR1",
                        PasswordHash = "AQAAAAEAACcQAAAAEPVdJa4I7jBTkwHn+QKSETEYTOTDO9TtNSe64Gtyl7x0SbjtK2rPeckofjOGwwLWKw==",
                        PhoneNumberConfirmed = false,
                        SecurityStamp = "519774b7-dd1b-430a-8b25-eef507ca1091",
                        TwoFactorEnabled = false,
                        UserName = "Director1"
                    });
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                b.Property<string>("ClaimType")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ClaimValue")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserClaims", "u1790493_1");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                b.Property<string>("LoginProvider")
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                b.Property<string>("ProviderKey")
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                b.Property<string>("ProviderDisplayName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.HasKey("LoginProvider", "ProviderKey");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserLogins", "u1790493_1");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                b.Property<string>("UserId")
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("RoleId")
                    .HasColumnType("nvarchar(450)");

                b.HasKey("UserId", "RoleId");

                b.HasIndex("RoleId");

                b.ToTable("AspNetUserRoles", "u1790493_1");

                b.HasData(
                    new
                    {
                        UserId = "519774b7-dd1b-430a-8b25-eef507ca1091",
                        RoleId = "33fbf4a6-31b3-4285-bbea-5929f98be3a3"
                    });
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                b.Property<string>("UserId")
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("LoginProvider")
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                b.Property<string>("Name")
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                b.Property<string>("Value")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("UserId", "LoginProvider", "Name");

                b.ToTable("AspNetUserTokens", "u1790493_1");
            });

            modelBuilder.Entity("RentApp.Data.Car", b =>
            {
                b.HasOne("RentApp.Data.Photo", "Photo")
                    .WithMany()
                    .HasForeignKey("PhotoId");

                b.HasOne("RentApp.Data.SegmentItem", "Segment")
                    .WithMany()
                    .HasForeignKey("SegmentId");

                b.Navigation("Photo");

                b.Navigation("Segment");
            });

            modelBuilder.Entity("RentApp.Data.Contract", b =>
            {
                b.HasOne("RentApp.Data.Car", "Car")
                    .WithMany("Contracts")
                    .HasForeignKey("CarId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("RentApp.Data.Driver", "Driver")
                    .WithMany()
                    .HasForeignKey("DriverId");

                b.Navigation("Car");

                b.Navigation("Driver");
            });

            modelBuilder.Entity("RentApp.Data.Expense", b =>
            {
                b.HasOne("RentApp.Data.Car", "Car")
                    .WithMany("Expenses")
                    .HasForeignKey("CarId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Car");
            });

            modelBuilder.Entity("RentApp.Data.MainHistory", b =>
            {
                b.HasOne("RentApp.Data.Car", null)
                    .WithMany("History")
                    .HasForeignKey("CarId");

                b.HasOne("RentApp.Data.Maintenance", "Maintenance")
                    .WithMany()
                    .HasForeignKey("MaintenanceId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Maintenance");
            });

            modelBuilder.Entity("RentApp.Data.Maintenance", b =>
            {
                b.HasOne("RentApp.Data.Car", "Car")
                    .WithMany("Maintenances")
                    .HasForeignKey("CarId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Car");
            });

            modelBuilder.Entity("RentApp.Data.Mileage", b =>
            {
                b.HasOne("RentApp.Data.Car", "Car")
                    .WithMany("Mileages")
                    .HasForeignKey("CarId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Car");
            });

            modelBuilder.Entity("RentApp.Data.Payment", b =>
            {
                b.HasOne("RentApp.Data.Contract", "Contract")
                    .WithMany("Payments")
                    .HasForeignKey("ContractId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Contract");
            });

            modelBuilder.Entity("RentApp.Data.Request", b =>
            {
                b.HasOne("RentApp.Data.Car", "Car")
                    .WithMany()
                    .HasForeignKey("CarId");

                b.HasOne("RentApp.Data.DistanceItem", "Distance")
                    .WithMany()
                    .HasForeignKey("DistanceId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Car");

                b.Navigation("Distance");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("RentApp.Data.Car", b =>
            {
                b.Navigation("Contracts");

                b.Navigation("Expenses");

                b.Navigation("History");

                b.Navigation("Maintenances");

                b.Navigation("Mileages");
            });

            modelBuilder.Entity("RentApp.Data.Contract", b =>
            {
                b.Navigation("Payments");
            });
#pragma warning restore 612, 618
        }
    }
}