﻿// <auto-generated />
using System;
using APBD_Projekt.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APBD_Projekt.Migrations
{
    [DbContext(typeof(IncManagerContext))]
    [Migration("20240627100633_Price for softwares")]
    partial class Priceforsoftwares
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APBD_Projekt.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Category_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Client_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("ClientAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address");

                    b.Property<string>("ClientEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("ClientTelNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("Tel_Num");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Contract_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContractId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("Client_ID");

                    b.Property<int?>("ContractActualisation")
                        .HasColumnType("int")
                        .HasColumnName("Actualisation");

                    b.Property<DateTime>("ContractDateFrom")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_From");

                    b.Property<DateTime>("ContractDateTo")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_To");

                    b.Property<decimal>("ContractPrice")
                        .HasColumnType("money")
                        .HasColumnName("Price");

                    b.Property<bool>("IsSigned")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Signed");

                    b.Property<int>("SoftwareVersionId")
                        .HasColumnType("int")
                        .HasColumnName("Version_ID");

                    b.HasKey("ContractId");

                    b.HasIndex("ClientId");

                    b.HasIndex("SoftwareVersionId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Discount_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"));

                    b.Property<DateTime>("DiscountDateFrom")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_From");

                    b.Property<DateTime>("DiscountDateTo")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_To");

                    b.Property<string>("DiscountDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Description");

                    b.Property<string>("DiscountName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Name");

                    b.HasKey("DiscountId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Firm", b =>
                {
                    b.Property<int>("FirmId")
                        .HasColumnType("int")
                        .HasColumnName("Client_ID");

                    b.Property<string>("FirmKRSNum")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("KRS");

                    b.Property<string>("FirmName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("FirmId");

                    b.ToTable("Firms");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Payment_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("money")
                        .HasColumnName("Amount");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("Client_ID");

                    b.Property<int>("ContractId")
                        .HasColumnType("int")
                        .HasColumnName("Contract_ID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.HasKey("PaymentId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ContractId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("APBD_Projekt.Models.PrivateClient", b =>
                {
                    b.Property<int>("PrivateClientId")
                        .HasColumnType("int")
                        .HasColumnName("Client_ID");

                    b.Property<string>("ClientFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("First_Name");

                    b.Property<string>("ClientLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Last_Name");

                    b.Property<string>("ClientPesel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("Pesel");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("Is_Deleted");

                    b.HasKey("PrivateClientId");

                    b.ToTable("Private_Clients");
                });

            modelBuilder.Entity("APBD_Projekt.Models.SoftwareDiscount", b =>
                {
                    b.Property<int>("SoftwareId")
                        .HasColumnType("int")
                        .HasColumnName("Software_ID");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int")
                        .HasColumnName("Discount_ID");

                    b.Property<int>("DiscountValue")
                        .HasColumnType("int")
                        .HasColumnName("Value");

                    b.HasKey("SoftwareId", "DiscountId");

                    b.HasIndex("DiscountId");

                    b.ToTable("Software_Discounts");
                });

            modelBuilder.Entity("APBD_Projekt.Models.SoftwareSystem", b =>
                {
                    b.Property<int>("SoftwareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Soft_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SoftwareId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("Category_ID");

                    b.Property<string>("SoftwareDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Description");

                    b.HasKey("SoftwareId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Software_Systems");
                });

            modelBuilder.Entity("APBD_Projekt.Models.SoftwareVersion", b =>
                {
                    b.Property<int>("VersionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Version_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VersionId"));

                    b.Property<int>("SoftwareId")
                        .HasColumnType("int")
                        .HasColumnName("Software_ID");

                    b.Property<string>("VersionInfo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Version_Info");

                    b.Property<string>("VersionNum")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Version");

                    b.Property<decimal>("VersionPrice")
                        .HasColumnType("money")
                        .HasColumnName("Price");

                    b.HasKey("VersionId");

                    b.HasIndex("SoftwareId");

                    b.ToTable("Software_Versions");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Worker_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerId"));

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Hashed_Password");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Refresh_Token");

                    b.Property<DateTime>("RefreshTokenExp")
                        .HasColumnType("datetime2")
                        .HasColumnName("Refresh_Token_Exp");

                    b.Property<string>("WorkerEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("WorkerLogin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Login");

                    b.HasKey("WorkerId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Contract", b =>
                {
                    b.HasOne("APBD_Projekt.Models.Client", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_Projekt.Models.SoftwareVersion", "SoftwareVersion")
                        .WithMany("Contracts")
                        .HasForeignKey("SoftwareVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("SoftwareVersion");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Firm", b =>
                {
                    b.HasOne("APBD_Projekt.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("FirmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Payment", b =>
                {
                    b.HasOne("APBD_Projekt.Models.Client", "Client")
                        .WithMany("Payments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("APBD_Projekt.Models.Contract", "Contract")
                        .WithMany("Payments")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("APBD_Projekt.Models.PrivateClient", b =>
                {
                    b.HasOne("APBD_Projekt.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("PrivateClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("APBD_Projekt.Models.SoftwareDiscount", b =>
                {
                    b.HasOne("APBD_Projekt.Models.Discount", "Discount")
                        .WithMany("SoftwareDiscounts")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD_Projekt.Models.SoftwareSystem", "SoftwareSystem")
                        .WithMany("SoftwareDiscounts")
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discount");

                    b.Navigation("SoftwareSystem");
                });

            modelBuilder.Entity("APBD_Projekt.Models.SoftwareSystem", b =>
                {
                    b.HasOne("APBD_Projekt.Models.Category", "Category")
                        .WithMany("SoftwareSystems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("APBD_Projekt.Models.SoftwareVersion", b =>
                {
                    b.HasOne("APBD_Projekt.Models.SoftwareSystem", "SoftwareSystem")
                        .WithMany("SoftwareVersions")
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SoftwareSystem");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Category", b =>
                {
                    b.Navigation("SoftwareSystems");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Client", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Contract", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("APBD_Projekt.Models.Discount", b =>
                {
                    b.Navigation("SoftwareDiscounts");
                });

            modelBuilder.Entity("APBD_Projekt.Models.SoftwareSystem", b =>
                {
                    b.Navigation("SoftwareDiscounts");

                    b.Navigation("SoftwareVersions");
                });

            modelBuilder.Entity("APBD_Projekt.Models.SoftwareVersion", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
