using FT.Domain.Entities;
using FT.Domain.Entities.FridgeAggregate;
using FT.Domain.Entities.ProductAggregate;
using FT.Domain.Entities.Users;
using FT.Persistence.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace FT.Persistence
{
    public class FTDBContext : DbContext//, IFTDBContext
    {
        private IConfiguration _configuration;

        public FTDBContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Fridge> Fridges { get; set; }

        public DbSet<Product> Products { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new FridgeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
    }

}
