namespace WardrobeApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using WardrobeApi.Data.Models;

    public class WardrobeContext : DbContext
    {
        private readonly DbContextOptions<WardrobeContext> _dbContextOptions;

        public WardrobeContext(DbContextOptions<WardrobeContext> dbContextOptions)
            : base(dbContextOptions)
        {
            this._dbContextOptions = dbContextOptions;
        }

        public DbSet<ClothingItem> ClothingItems { get; set; } = default!;

        public DbSet<Outfit> Outfits { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the many-to-many relationship between Outfit and Item
            modelBuilder.Entity<OutfitItem>()
                .HasKey(oi => new { oi.OutfitId, oi.ClothingItemId });

            modelBuilder.Entity<OutfitItem>()
                .HasOne(oi => oi.Outfit)
                .WithMany(o => o.OutfitItems)
                .HasForeignKey(oi => oi.OutfitId);

            modelBuilder.Entity<OutfitItem>()
                .HasOne(oi => oi.ClothingItem)
                .WithMany(i => i.OutfitItems)
                .HasForeignKey(oi => oi.ClothingItemId);
        }
    }
}
