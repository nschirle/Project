﻿
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financial
{
    public class DBinterface : DbContext
    {
        public virtual DbSet<InvestmentTracker> InvestmentTracker { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<YearTracker> YearTracker { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=InvestmentDB;Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                .HasName("PK_Account");

                entity.Property(e => e.AccountNumber)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.EmailAddress)
                .HasMaxLength(50);

                entity.ToTable("Account");
            });
            modelBuilder.Entity<InvestmentTracker>(entity =>
            {
                entity.HasKey(e => e.TrackingNumber)
                .HasName("PK_Transaction");

                entity.Property(e => e.TrackingNumber)
                .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Account);


                entity.ToTable("InvestmentTracker");
            });
            modelBuilder.Entity<YearTracker>(entity =>
            {
                entity.HasKey(e => e.YearTrackingNumber)
                .HasName("PK_YearTrackingNumber");

                entity.Property(e => e.YearTrackingNumber)
                .ValueGeneratedOnAdd();

                entity.HasOne(e => e.InvestmentTracker);

                entity.ToTable("YearTracker");
            });
        }
    }
}