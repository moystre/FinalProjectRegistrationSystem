using CustomerAppDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL.Context
{
    class CustomerAppContext : DbContext
    {
        static DbContextOptions<CustomerAppContext> options = new DbContextOptionsBuilder<CustomerAppContext>().UseInMemoryDatabase("TheDB").Options;
        /*public CustomerAppContext() : base(options)
        {
            
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddress>().HasKey(ca => new { ca.AddressId, ca.CustomerId });//Combined key in the database

            modelBuilder.Entity<CustomerAddress>().HasOne(ca => ca.Address).WithMany(a => a.Customers).HasForeignKey(ca => ca.AddressId);

            modelBuilder.Entity<CustomerAddress>().HasOne(ca => ca.Customer).WithMany(c => c.Addresses).HasForeignKey(ca => ca.CustomerId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
