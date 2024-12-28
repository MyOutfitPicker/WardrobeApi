namespace MyWardrobeApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyWardrobeApi.Models;

    public class WardrobeContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<Outfit> Outfits { get; set; }

        public WardrobeContext(DbContextOptions<WardrobeContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the many-to-many relationship
            modelBuilder.Entity<OutfitItem>()
                .HasKey(oi => new { oi.OutfitId, oi.ItemId });

            modelBuilder.Entity<OutfitItem>()
                .HasOne(oi => oi.Outfit)
                .WithMany(o => o.OutfitItems)
                .HasForeignKey(oi => oi.OutfitId);

            modelBuilder.Entity<OutfitItem>()
                .HasOne(oi => oi.Item)
                .WithMany(i => i.OutfitItems)
                .HasForeignKey(oi => oi.ItemId);
        }
    }
}
