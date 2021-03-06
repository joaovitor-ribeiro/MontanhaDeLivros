﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MontanhasDeLivros.Models;

namespace MontanhaDeLivros.Migrations
{
    [DbContext(typeof(MontanhasDeLivrosContext))]
    [Migration("20210423225347_removido-seller-da-salesrecord")]
    partial class removidosellerdasalesrecord
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MontanhasDeLivros.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmountBook");

                    b.Property<string>("Author");

                    b.Property<string>("Description");

                    b.Property<float>("Price");

                    b.Property<string>("Publisher");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("MontanhasDeLivros.Models.SalesRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int?>("BookId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Quantity");

                    b.Property<int?>("SellerId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("SellerId");

                    b.ToTable("SalesRecord");
                });

            modelBuilder.Entity("MontanhasDeLivros.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BaseSalary");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("MontanhasDeLivros.Models.SalesRecord", b =>
                {
                    b.HasOne("MontanhasDeLivros.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("MontanhasDeLivros.Models.Seller")
                        .WithMany("Sales")
                        .HasForeignKey("SellerId");
                });
#pragma warning restore 612, 618
        }
    }
}
