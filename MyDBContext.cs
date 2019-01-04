using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_Web_API_Orders.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("constr")
        {

        }
        public DbSet<OrderModel> Orders { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderModel>().ToTable("tbl_orders");
            modelBuilder.Entity<OrderModel>().HasKey(p => p.OrderID);
            modelBuilder.Entity<OrderModel>().Property(p => p.ItemName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<OrderModel>().Property(p => p.CustomerMobileNo).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<OrderModel>().Property(p => p.ItemPrice).IsRequired();
            modelBuilder.Entity<OrderModel>().Property(p => p.ItemQuantity).IsRequired();
        }
    }
}