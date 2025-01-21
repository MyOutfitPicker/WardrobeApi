// -----------------------------------------------------------------------
// <copyright file="WardrobeContext.cs" company="WardrobeApi">
//     Copyright (c) WardrobeApi. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Represents the database context for the Wardrobe database.
// </summary>
// -----------------------------------------------------------------------

namespace WardrobeApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using WardrobeApi.Data.Models;

    /// <summary>
    /// Represents the database context for the Wardrobe application.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="WardrobeContext"/> class.
    /// </remarks>
    /// <param name="options">The options to configure the database context.</param>
    public class WardrobeContext : DbContext
    {
        private readonly DbContextOptions<WardrobeContext> _dbContextOptions;

        public WardrobeContext(DbContextOptions<WardrobeContext> dbContextOptions)
            : base(dbContextOptions)
        {
            this._dbContextOptions = dbContextOptions;
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of items in the wardrobe.
        /// </summary>
        public DbSet<ClothingItem> ClothingItems { get; set; } = default!;

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of outfits in the wardrobe.
        /// </summary>
        public DbSet<Outfit> Outfits { get; set; } = default!;

        /// <summary>
        /// Configures the entity relationships and database schema during model creation.
        /// </summary>
        /// <param name="modelBuilder">The builder used to configure the entity framework model.</param>
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
