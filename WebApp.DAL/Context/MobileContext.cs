using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.DAL.Maps;

namespace WebApp.DAL.Context
{
    public class MobileContext : DbContext
    {
        public MobileContext(DbContextOptions<MobileContext> options) : base(options)
        {
            DbInitialize.Seed(this);
        }

        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new PhoneMap(modelBuilder.Entity<Phone>());
        }
    }
}