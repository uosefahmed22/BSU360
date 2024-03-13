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
    [DbContext(typeof(BusnissDbContext))]
    [Migration("20240313001920_BusinessinitialMigration")]
    partial class BusinessinitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<string>("AlbumUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameAR")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameENG")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ContactInfoId");

                    b.HasIndex("LocationId");

                    b.ToTable("Busnisses");
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

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.FavoriteBusniss", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusnissId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "BusnissId");

                    b.ToTable("FavoriteBusnisses");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BusinessModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BusinessModelId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.WorkTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("WorkTime");
                });

            modelBuilder.Entity("Account.Core.Models.Projectbusiness.BusinessModel", b =>
                {
                    b.HasOne("Account.Core.Models.ProjectBusiness.Category", "Category")
                        .WithMany("Businesses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Account.Core.Models.ProjectBusiness.Contact", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactInfoId");

                    b.HasOne("Account.Core.Models.ProjectBusiness.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Category");

                    b.Navigation("ContactInfo");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Review", b =>
                {
                    b.HasOne("Account.Core.Models.Projectbusiness.BusinessModel", null)
                        .WithMany("Reviews")
                        .HasForeignKey("BusinessModelId");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.WorkTime", b =>
                {
                    b.HasOne("Account.Core.Models.Projectbusiness.BusinessModel", null)
                        .WithMany("WorkTimes")
                        .HasForeignKey("BusinessId");
                });

            modelBuilder.Entity("Account.Core.Models.Projectbusiness.BusinessModel", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("WorkTimes");
                });

            modelBuilder.Entity("Account.Core.Models.ProjectBusiness.Category", b =>
                {
                    b.Navigation("Businesses");
                });
#pragma warning restore 612, 618
        }
    }
}
