﻿// <auto-generated />
using System;
using Financial;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Financial.Migrations
{
    [DbContext(typeof(DBinterface))]
    [Migration("20181204231720_newvariables")]
    partial class newvariables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Financial.Account", b =>
                {
                    b.Property<int>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(50);

                    b.Property<double>("ExpectedInflation");

                    b.Property<string>("FirstName");

                    b.Property<double>("Income");

                    b.Property<double>("Interest");

                    b.Property<string>("LastName");

                    b.Property<double>("PercentOfSalarySaved");

                    b.Property<int>("YearsInPeriod");

                    b.HasKey("AccountNumber")
                        .HasName("PK_Account");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Financial.InvestmentTracker", b =>
                {
                    b.Property<int>("TrackingNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountNumber");

                    b.Property<double>("TotalSaved");

                    b.Property<double>("TotalSavedInflated");

                    b.HasKey("TrackingNumber")
                        .HasName("PK_Transaction");

                    b.HasIndex("AccountNumber");

                    b.ToTable("InvestmentTracker");
                });

            modelBuilder.Entity("Financial.YearTracker", b =>
                {
                    b.Property<int>("YearTrackingNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TrackingNumber");

                    b.Property<double>("Value");

                    b.Property<double>("ValueInflated");

                    b.Property<int>("Year");

                    b.HasKey("YearTrackingNumber")
                        .HasName("PK_YearTrackingNumber");

                    b.HasIndex("TrackingNumber");

                    b.ToTable("YearTracker");
                });

            modelBuilder.Entity("Financial.InvestmentTracker", b =>
                {
                    b.HasOne("Financial.Account", "Account")
                        .WithMany("InvestmentTracker")
                        .HasForeignKey("AccountNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Financial.YearTracker", b =>
                {
                    b.HasOne("Financial.InvestmentTracker", "InvestmentTracker")
                        .WithMany()
                        .HasForeignKey("TrackingNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
