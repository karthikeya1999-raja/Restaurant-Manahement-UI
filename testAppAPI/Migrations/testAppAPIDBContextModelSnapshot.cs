﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testAppAPI.Models;

namespace testAppAPI.Migrations
{
    [DbContext(typeof(testAppAPIDBContext))]
    partial class testAppAPIDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("testAppAPI.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<int>("IsAdmin")
                        .HasColumnType("int")
                        .HasColumnName("is_admin");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("testAppAPI.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("dish");
                });

            modelBuilder.Entity("testAppAPI.Models.DishCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost")
                        .HasColumnType("int")
                        .HasColumnName("cost");

                    b.Property<int>("DishId")
                        .HasColumnType("int")
                        .HasColumnName("dish_id");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("img_url");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int")
                        .HasColumnName("restaurant_id");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("dish-cost");
                });

            modelBuilder.Entity("testAppAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<int>("DishId")
                        .HasColumnType("int")
                        .HasColumnName("dish_id");

                    b.Property<string>("OrderDate")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("order_date");

                    b.Property<int>("OrderQuantity")
                        .HasColumnType("int")
                        .HasColumnName("order_quantity");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int")
                        .HasColumnName("restaurant_id");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DishId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("testAppAPI.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("img_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(7)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("restaurant");
                });

            modelBuilder.Entity("testAppAPI.Models.DishCost", b =>
                {
                    b.HasOne("testAppAPI.Models.Dish", "Dish")
                        .WithMany("DishCost")
                        .HasForeignKey("DishId")
                        .HasConstraintName("FK_dish_dish-cost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testAppAPI.Models.Restaurant", "Restaurant")
                        .WithMany("DishCost")
                        .HasForeignKey("RestaurantId")
                        .HasConstraintName("FK_dish-cost_restaurant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("testAppAPI.Models.Order", b =>
                {
                    b.HasOne("testAppAPI.Models.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_order_customer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testAppAPI.Models.Dish", "Dish")
                        .WithMany("Order")
                        .HasForeignKey("DishId")
                        .HasConstraintName("FK_dish_customer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testAppAPI.Models.Restaurant", "Restaurant")
                        .WithMany("Order")
                        .HasForeignKey("RestaurantId")
                        .HasConstraintName("FK_restaurant_customer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Dish");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("testAppAPI.Models.Customer", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("testAppAPI.Models.Dish", b =>
                {
                    b.Navigation("DishCost");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("testAppAPI.Models.Restaurant", b =>
                {
                    b.Navigation("DishCost");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
