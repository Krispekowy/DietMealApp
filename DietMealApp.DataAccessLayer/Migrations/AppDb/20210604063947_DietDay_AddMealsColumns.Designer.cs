﻿// <auto-generated />
using System;
using DietMealApp.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DietMealApp.DataAccessLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210604063947_DietDay_AddMealsColumns")]
    partial class DietDay_AddMealsColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DietMealApp.Core.Entities.Diet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanBeEdited")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DietName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("DietMealApp.Core.Entities.DietDay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Breakfast")
                        .HasColumnType("int");

                    b.Property<int>("Brunch")
                        .HasColumnType("int");

                    b.Property<bool>("CanBeEdited")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.Property<Guid?>("DietId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Dinner")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Kcal")
                        .HasColumnType("int");

                    b.Property<int>("Lunch")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tea")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DietId1");

                    b.ToTable("DietDays");
                });

            modelBuilder.Entity("DietMealApp.Core.Entities.DietDayMeals", b =>
                {
                    b.Property<Guid>("DietDayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanBeEdited")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("DietDayId", "MealId");

                    b.HasIndex("MealId");

                    b.ToTable("DayDietMeals");
                });

            modelBuilder.Entity("DietMealApp.Core.Entities.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanBeEdited")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Kcal")
                        .HasColumnType("int");

                    b.Property<string>("MealName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeOfMeal")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("DietMealApp.Core.Entities.MealProduct", b =>
                {
                    b.Property<Guid>("MealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanBeEdited")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("MealId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("MealProducts");
                });

            modelBuilder.Entity("DietMealApp.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanBeEdited")
                        .HasColumnType("bit");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Kcal")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityUnit")
                        .HasColumnType("int");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DietMealApp.Core.Entities.DietDay", b =>
                {
                    b.HasOne("DietMealApp.Core.Entities.Diet", "Diet")
                        .WithMany("Days")
                        .HasForeignKey("DietId1");

                    b.Navigation("Diet");
                });

            modelBuilder.Entity("DietMealApp.Core.Entities.DietDayMeals", b =>
                {
                    b.HasOne("DietMealApp.Core.Entities.DietDay", "DayDiet")
                        .WithMany("DayDietMeals")
                        .HasForeignKey("DietDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietMealApp.Core.Entities.Meal", "Meal")
                        .WithMany("DayDietMeals")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayDiet");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("DietMealApp.Core.Entities.MealProduct", b =>
                {
                    b.HasOne("DietMealApp.Core.Entities.Meal", "Meal")
                        .WithMany("MealProducts")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietMealApp.Core.Entities.Product", "Product")
                        .WithMany("MealProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meal");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DietMealApp.Core.Entities.Diet", b =>
                {
                    b.Navigation("Days");
                });

            modelBuilder.Entity("DietMealApp.Core.Entities.DietDay", b =>
                {
                    b.Navigation("DayDietMeals");
                });

            modelBuilder.Entity("DietMealApp.Core.Entities.Meal", b =>
                {
                    b.Navigation("DayDietMeals");

                    b.Navigation("MealProducts");
                });

            modelBuilder.Entity("DietMealApp.Core.Entities.Product", b =>
                {
                    b.Navigation("MealProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
