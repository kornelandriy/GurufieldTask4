using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.DAL.Maps;

namespace WebApp.DAL.Context
{
    public class MobileContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public MobileContext(DbContextOptions<MobileContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder); 
            new PhoneMap(modelBuilder.Entity<Phone>()); 
        } 
    }
}