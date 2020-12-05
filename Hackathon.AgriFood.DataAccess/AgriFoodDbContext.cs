using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Models.Models.Relations;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.AgriFood.DataAccess
{
    public class AgriFoodDbContext : DbContext
    {
        public AgriFoodDbContext(DbContextOptions<AgriFoodDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<FarmerPhoto> FarmerPhotos { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopPhoto> ShopPhotos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ShopToFarmer> ShopToFarmers { get; set; }
        public DbSet<CustomerToFarmer> CustomerToFarmers { get; set; }
        public DbSet<CustomerToProduct> CustomerToProducts { get; set; }
        public DbSet<CustomerToShop> CustomerToShops { get; set; }
        public DbSet<TagToProduct> TagToProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // OneToMany Relations

            builder.Entity<Farmer>()
                .HasOne(f => f.Localization)
                .WithMany(l => l.Farmers)
                .HasForeignKey(f => f.LocalizationId);

            builder.Entity<Shop>()
                .HasOne(s => s.Localization)
                .WithMany(l => l.Shops)
                .HasForeignKey(s => s.LocalizationId);

            builder.Entity<Product>()
                .HasOne(p => p.Farmer)
                .WithMany(f => f.Products)
                .HasForeignKey(p => p.FarmerId);

            builder.Entity<Product>()
                .HasOne(p => p.Shop)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.ShopId);

            builder.Entity<FarmerPhoto>()
                .HasOne(fp => fp.Farmer)
                .WithMany(f => f.Photos)
                .HasForeignKey(fp => fp.FarmerId);

            builder.Entity<ProductPhoto>()
                .HasOne(pp => pp.Product)
                .WithMany(p => p.Photos)
                .HasForeignKey(pp => pp.ProductId);

            builder.Entity<ShopPhoto>()
                .HasOne(sp => sp.Shop)
                .WithMany(s => s.Photos)
                .HasForeignKey(sp => sp.ShopId);

            // ManyToMany Relations

            builder.Entity<CustomerToFarmer>()
                .HasKey(ctf => new { ctf.CustomerId, ctf.FarmerId });
            builder.Entity<CustomerToFarmer>()
                .HasOne(ctf => ctf.Customer)
                .WithMany(c => c.FavoriteFarmers)
                .HasForeignKey(ctf => ctf.FarmerId);
            builder.Entity<CustomerToFarmer>()
                .HasOne(ctf => ctf.Farmer)
                .WithMany(f => f.FavoringCustomers)
                .HasForeignKey(ctf => ctf.CustomerId);

            builder.Entity<CustomerToProduct>()
                .HasKey(ctp => new { ctp.CustomerId, ctp.ProductId });
            builder.Entity<CustomerToProduct>()
                .HasOne(ctp => ctp.Customer)
                .WithMany(c => c.FavoriteProducts)
                .HasForeignKey(ctp => ctp.ProductId);
            builder.Entity<CustomerToProduct>()
                .HasOne(ctp => ctp.Product)
                .WithMany(p => p.FavoringCustomers)
                .HasForeignKey(ctp => ctp.CustomerId);

            builder.Entity<CustomerToShop>()
                .HasKey(cts => new { cts.CustomerId, cts.ShopId });
            builder.Entity<CustomerToShop>()
                .HasOne(cts => cts.Customer)
                .WithMany(c => c.FavoriteShops)
                .HasForeignKey(cts => cts.ShopId);
            builder.Entity<CustomerToShop>()
                .HasOne(cts => cts.Shop)
                .WithMany(s => s.FavoringCustomers)
                .HasForeignKey(cts => cts.CustomerId);

            builder.Entity<CustomerToFarmer>()
                .HasKey(ctf => new { ctf.CustomerId, ctf.FarmerId });
            builder.Entity<CustomerToFarmer>()
                .HasOne(ctf => ctf.Customer)
                .WithMany(c => c.FavoriteFarmers)
                .HasForeignKey(ctf => ctf.FarmerId);
            builder.Entity<CustomerToFarmer>()
                .HasOne(ctf => ctf.Farmer)
                .WithMany(f => f.FavoringCustomers)
                .HasForeignKey(ctf => ctf.CustomerId);

            builder.Entity<ShopToFarmer>()
                .HasKey(stf => new { stf.ShopId, stf.FarmerId });
            builder.Entity<ShopToFarmer>()
                .HasOne(stf => stf.Shop)
                .WithMany(s => s.Farmers)
                .HasForeignKey(stf => stf.ShopId);
            builder.Entity<ShopToFarmer>()
                .HasOne(stf => stf.Farmer)
                .WithMany(f => f.Shops)
                .HasForeignKey(stf => stf.FarmerId);

            builder.Entity<TagToProduct>()
                .HasKey(ttp => new { ttp.TagId, ttp.ProductId});
            builder.Entity<TagToProduct>()
                .HasOne(ttp => ttp.Tag)
                .WithMany(t => t.TaggedProducts)
                .HasForeignKey(ttp => ttp.TagId);
            builder.Entity<TagToProduct>()
                .HasOne(ttp => ttp.Product)
                .WithMany(p => p.Tags)
                .HasForeignKey(ttp => ttp.ProductId);
        }
    }
}