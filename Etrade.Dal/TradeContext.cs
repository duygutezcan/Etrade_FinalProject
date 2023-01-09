using Etrade.Entity.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Dal
{
    public class TradeContext:DbContext
    {
        public TradeContext(DbContextOptions<TradeContext> db):base(db)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketDetail>()
                .HasKey(b => new { b.Id, b.ProductId }); 

        }
        public DbSet<City> City { get; set; }
        public DbSet<County> County { get; set; }
        public DbSet<BasketDetail> BasketDetail { get; set; }
        public DbSet<BasketMaster> BasketMaster { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }   
        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }

    }
}
