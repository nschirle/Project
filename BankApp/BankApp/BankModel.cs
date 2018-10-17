
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class BankModel : DbContext
    {
       public BankModel() : base()
        {

        }
        public BankModel(DbContextOptions<BankModel> options) : base(options)
        {

        }

        public virtual DbSet<Account> Accounts { get; set; }
    }
}
