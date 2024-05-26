﻿// <auto-generated />
using System;
using BackendTeamwork.Databases;
using BackendTeamwork.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240522203325_db-init-4")]
    partial class dbinit4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "role", new[] { "customer", "admin" });
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pgcrypto");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BackendTeamwork.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("AddressLine")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("address_line");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("city");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("zip");

                    b.HasKey("Id")
                        .HasName("pk_address");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasDatabaseName("ix_address_user_id");

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_brand");

                    b.ToTable("brand", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_category");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uuid")
                        .HasColumnName("payment_id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_order");

                    b.HasIndex("PaymentId")
                        .IsUnique()
                        .HasDatabaseName("ix_order_payment_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_order_user_id");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.OrderStock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<Guid>("StockId")
                        .HasColumnType("uuid")
                        .HasColumnName("stock_id");

                    b.HasKey("Id")
                        .HasName("pk_order_stock");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_stock_order_id");

                    b.HasIndex("StockId")
                        .HasDatabaseName("ix_order_stock_stock_id");

                    b.ToTable("order_stock", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision")
                        .HasColumnName("amount");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("method");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_payment");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_payment_user_id");

                    b.ToTable("payment", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uuid")
                        .HasColumnName("brand_id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<int>("NumberOfSales")
                        .HasColumnType("integer")
                        .HasColumnName("number_of_sales");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_product");

                    b.HasIndex("BrandId")
                        .HasDatabaseName("ix_product_brand_id");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_product_category_id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_product_name");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.ProductWishlist", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<Guid>("WishlistId")
                        .HasColumnType("uuid")
                        .HasColumnName("wishlist_id");

                    b.HasKey("ProductId", "WishlistId")
                        .HasName("pk_product_wishlist");

                    b.HasIndex("WishlistId")
                        .HasDatabaseName("ix_product_wishlist_wishlist_id");

                    b.ToTable("product_wishlist", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("comment");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_review");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_review_product_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_review_user_id");

                    b.ToTable("review", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Shipping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("address_id");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<string>("DeliveryMethod")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("delivery_method");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<string>("TrackingNo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("tracking_no");

                    b.HasKey("Id")
                        .HasName("pk_shipping");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasDatabaseName("ix_shipping_address_id");

                    b.HasIndex("OrderId")
                        .IsUnique()
                        .HasDatabaseName("ix_shipping_order_id");

                    b.ToTable("shipping", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("color");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("condition");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("size");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_stock");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_stock_product_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_stock_user_id");

                    b.ToTable("stock", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.StockImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean")
                        .HasColumnName("is_main");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("size");

                    b.Property<Guid>("StockId")
                        .HasColumnType("uuid")
                        .HasColumnName("stock_id");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_stock_image");

                    b.HasIndex("StockId")
                        .HasDatabaseName("ix_stock_image_stock_id");

                    b.ToTable("stock_image", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("phone");

                    b.Property<Role>("Role")
                        .HasColumnType("role")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_user_email");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Wishlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_wishlist");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_wishlist_user_id");

                    b.ToTable("wishlist", (string)null);
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Address", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("BackendTeamwork.Entities.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_address_user_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Order", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Payment", "Payment")
                        .WithOne("Order")
                        .HasForeignKey("BackendTeamwork.Entities.Order", "PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_payment_payment_id");

                    b.HasOne("BackendTeamwork.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_user_user_id");

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.OrderStock", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Order", "Order")
                        .WithMany("OrderStocks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_stock_order_order_id");

                    b.HasOne("BackendTeamwork.Entities.Stock", "Stock")
                        .WithMany("OrderStocks")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_stock_stock_stock_id");

                    b.Navigation("Order");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Payment", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_payment_user_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Product", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_brand_brand_id");

                    b.HasOne("BackendTeamwork.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_category_category_id");

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.ProductWishlist", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Product", null)
                        .WithMany("Wishlists")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_wishlist_product_product_id");

                    b.HasOne("BackendTeamwork.Entities.Wishlist", null)
                        .WithMany("Products")
                        .HasForeignKey("WishlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_wishlist_wishlist_wishlist_id");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Review", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_review_product_product_id");

                    b.HasOne("BackendTeamwork.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_review_user_user_id");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Shipping", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Address", "Address")
                        .WithOne("Shipping")
                        .HasForeignKey("BackendTeamwork.Entities.Shipping", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shipping_address_address_id");

                    b.HasOne("BackendTeamwork.Entities.Order", "Order")
                        .WithOne("Shipping")
                        .HasForeignKey("BackendTeamwork.Entities.Shipping", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shipping_order_order_id");

                    b.Navigation("Address");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Stock", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_stock_product_product_id");

                    b.HasOne("BackendTeamwork.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_stock_user_user_id");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.StockImage", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.Stock", "Stock")
                        .WithMany("StockImage")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_stock_image_stock_stock_id");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Wishlist", b =>
                {
                    b.HasOne("BackendTeamwork.Entities.User", "User")
                        .WithMany("Wishlists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_wishlist_user_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Address", b =>
                {
                    b.Navigation("Shipping")
                        .IsRequired();
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Order", b =>
                {
                    b.Navigation("OrderStocks");

                    b.Navigation("Shipping")
                        .IsRequired();
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Payment", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Product", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Stocks");

                    b.Navigation("Wishlists");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Stock", b =>
                {
                    b.Navigation("OrderStocks");

                    b.Navigation("StockImage");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Payments");

                    b.Navigation("Reviews");

                    b.Navigation("Wishlists");
                });

            modelBuilder.Entity("BackendTeamwork.Entities.Wishlist", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
