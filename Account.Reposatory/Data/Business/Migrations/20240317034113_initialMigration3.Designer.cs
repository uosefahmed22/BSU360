﻿// <auto-generated />
using System;
using Account.Reposatory.Data.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Account.Reposatory.Data.Business.Migrations
{
    [DbContext(typeof(BusinessDbContext))]
    [Migration("20240317034113_initialMigration3")]
    partial class initialMigration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Account.Core.Models.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("Account.Core.Models.Projectbusiness.BusinessModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AboutAR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutENG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlbumUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(10,8)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(11,8)");

                    b.Property<string>("NameAR")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameENG")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkEndHour")
                        .HasColumnType("int");

                    b.Property<int>("WorkStartHour")
                        .HasColumnType("int");

                    b.Property<int>("WorkingDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Contacts.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BusinessModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessModelId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Contacts.Emails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Contacts.PhoneNumbers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Favorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BusinessModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("HolidayDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BusinessModelId");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Account.Core.Models.Projectbusiness.BusinessModel", b =>
                {
                    b.HasOne("Account.Core.Models.ProjectBusiness.Category", "Category")
                        .WithMany("Businesses")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Contacts.Contact", b =>
                {
                    b.HasOne("Account.Core.Models.Projectbusiness.BusinessModel", null)
                        .WithMany("Contacts")
                        .HasForeignKey("BusinessModelId");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Contacts.Emails", b =>
                {
                    b.HasOne("Account.Core.Models.ProjectBusiness.Contacts.Contact", "Contact")
                        .WithMany("Emails")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Contacts.PhoneNumbers", b =>
                {
                    b.HasOne("Account.Core.Models.ProjectBusiness.Contacts.Contact", "Contact")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Favorite", b =>
                {
                    b.HasOne("Account.Core.Models.Projectbusiness.BusinessModel", "Business")
                        .WithMany("BusinessFavorites")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Account.Core.Models.Identity.AppUser", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId");

                    b.Navigation("Business");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Holiday", b =>
                {
                    b.HasOne("Account.Core.Models.Projectbusiness.BusinessModel", null)
                        .WithMany("Holidays")
                        .HasForeignKey("BusinessModelId");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Rating", b =>
                {
                    b.HasOne("Account.Core.Models.Projectbusiness.BusinessModel", "Business")
                        .WithMany("BusinessRatings")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Review", b =>
                {
                    b.HasOne("Account.Core.Models.Projectbusiness.BusinessModel", "Business")
                        .WithMany("BusinessReviews")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("Account.Core.Models.Identity.AppUser", b =>
                {
                    b.Navigation("Favorites");
                });

            modelBuilder.Entity("Account.Core.Models.Projectbusiness.BusinessModel", b =>
                {
                    b.Navigation("BusinessFavorites");

                    b.Navigation("BusinessRatings");

                    b.Navigation("BusinessReviews");

                    b.Navigation("Contacts");

                    b.Navigation("Holidays");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Category", b =>
                {
                    b.Navigation("Businesses");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Contacts.Contact", b =>
                {
                    b.Navigation("Emails");

                    b.Navigation("PhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
