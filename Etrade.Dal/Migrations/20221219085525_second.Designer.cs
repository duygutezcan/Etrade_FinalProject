﻿// <auto-generated />
using System;
using Etrade.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Etrade.Dal.Migrations
{
    [DbContext(typeof(TradeContext))]
    [Migration("20221219085525_second")]
    partial class second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Etrade.Entity.Concretes.BasketDetail", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketDetail");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.BasketMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.ToTable("BasketMaster");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.County", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("County");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("imgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("isHome")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Avenue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountyId")
                        .HasColumnType("int");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Error")
                        .HasColumnType("bit");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.BasketDetail", b =>
                {
                    b.HasOne("Etrade.Entity.Concretes.BasketMaster", "BasketMaster")
                        .WithMany("BasketDetails")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Etrade.Entity.Concretes.Products", "Products")
                        .WithMany("BasketDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasketMaster");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.BasketMaster", b =>
                {
                    b.HasOne("Etrade.Entity.Concretes.Users", "Users")
                        .WithMany("BasketMaster")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.County", b =>
                {
                    b.HasOne("Etrade.Entity.Concretes.City", "City")
                        .WithMany("Counties")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.Products", b =>
                {
                    b.HasOne("Etrade.Entity.Concretes.Categories", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.Users", b =>
                {
                    b.HasOne("Etrade.Entity.Concretes.County", "County")
                        .WithMany("Users")
                        .HasForeignKey("CountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("County");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.BasketMaster", b =>
                {
                    b.Navigation("BasketDetails");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.City", b =>
                {
                    b.Navigation("Counties");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.County", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.Products", b =>
                {
                    b.Navigation("BasketDetails");
                });

            modelBuilder.Entity("Etrade.Entity.Concretes.Users", b =>
                {
                    b.Navigation("BasketMaster");
                });
#pragma warning restore 612, 618
        }
    }
}
