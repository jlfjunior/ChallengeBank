﻿using ChallengeBank.Domain.Entities;
using ChallengeBank.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ChallengeBank.Infra
{
    public class Context : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }

        public Context(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().Map();
        }
    }
}
