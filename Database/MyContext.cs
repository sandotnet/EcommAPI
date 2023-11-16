using EcommAPI.Entities;
using Microsoft.EntityFrameworkCore;
namespace EcommAPI.Database
{
    public class MyContext:DbContext
    {
        //define entity set
        public DbSet<User>? Users { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Order> Orders { get; set; }    
        //configure connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-4O1D65I\\SQLEXPRESS;database=EComm11DB;trusted_connection=true;TrustServerCertificate=True");
        }
    }
}
