﻿// <auto-generated />
using System;
using Ilvbu.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ilvbu.DataBase.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Ilvbu.DataBase.Models.FoodRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("FoodName")
                        .HasMaxLength(64);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FoodRecord");
                });

            modelBuilder.Entity("Ilvbu.DataBase.Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OpenId")
                        .HasMaxLength(64);

                    b.Property<string>("Password")
                        .HasMaxLength(128);

                    b.Property<string>("UserName")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("Ilvbu.DataBase.Models.WxLoginRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExpiresIn")
                        .HasMaxLength(64);

                    b.Property<string>("Guid")
                        .HasMaxLength(128);

                    b.Property<string>("SessionKey")
                        .HasMaxLength(64);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WxLoginRecord");
                });

            modelBuilder.Entity("Ilvbu.DataBase.Models.FoodRecord", b =>
                {
                    b.HasOne("Ilvbu.DataBase.Models.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ilvbu.DataBase.Models.WxLoginRecord", b =>
                {
                    b.HasOne("Ilvbu.DataBase.Models.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
