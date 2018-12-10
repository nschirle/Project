
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class BankModel : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=Bankdb;Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
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

                entity.HasMany(e => e.Transactions);

                entity.ToTable("Accounts");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionID)
                .HasName("PK_Transaction");

                entity.Property(e => e.TransactionID)
                .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Account);
                

                entity.ToTable("Transactions");
            });
        }

        /*public BankModel() : base()
         {

         }
         public BankModel(DbContextOptions<BankModel> options) : base(options)
         {

         }

         public virtual DbSet<Account> Accounts { get; set; }
     }*/
    }
}
