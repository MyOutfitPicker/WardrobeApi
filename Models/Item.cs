// -----------------------------------------------------------------------
// <copyright file="Item.cs" company="MyWardrobe">
//     Copyright (c) MyWardrobe. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Defines the Item entity, which represents a single clothing or accessory item
//     within the MyWardrobe application.
// </summary>

namespace MyWardrobeApi.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MyWardrobeApi.Enums;

    /// <summary>
    /// Represents a single clothing or accessory item in the wardrobe.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the unique identifier for this item.
        /// </summary>
        /// <value>The unique string-based identifier (e.g., a GUID or another format).</value>
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the display name of the item (e.g., "Nike Air Max Sneakers").
        /// </summary>
        /// <value>A human-readable name for the item.</value>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Gets or sets the high-level category or type of the item.
        /// </summary>
        /// <value>An <see cref="ItemType"/> enum value representing the item's category (e.g., Top, Bottom, Footwear).</value>
        [Required]
        public ItemType Type { get; set; } = default!;

        /// <summary>
        /// Gets or sets the brand name of the item, if applicable.
        /// </summary>
        /// <value>The brand (e.g., "Nike", "Levi's", etc.).</value>
        [MaxLength(50)]
        public string? Brand { get; set; } = default!;

        /// <summary>
        /// Gets or sets the color of the item.
        /// </summary>
        /// <value>A <see cref="Color"/> enum value representing the item's color.</value>
        public Color? Color { get; set; }

        /// <summary>
        /// Gets or sets the size of the item (e.g., "M", "L", "32W").
        /// </summary>
        /// <value>A string indicating the size.</value>
        [MaxLength(50)]
        public string? Size { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="User"/> object that created this outfit.
        /// </summary>
        /// <value>A navigation property to the user who owns or created the outfit.</value>
        // public ApplicationUser CreatedByUser { get; set; } = default!;

        /// <summary>
        /// Gets or sets the ID of the user who created this item.
        /// </summary>
        /// <value>An integer representing the user's primary key (e.g., in the Users table).</value>
        // [ForeignKey("ApplicationUser")]
        // [Required]
        // public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time (in UTC) when this item was created.
        /// </summary>
        /// <value>A <see cref="DateTime"/> indicating when the record was created.</value>
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the date and time (in UTC) when this item was last updated.
        /// </summary>
        /// <value>A <see cref="DateTime"/> indicating the last modification time.</value>
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the collection of outfit-item associations for this item.
        /// </summary>
        /// <value>A collection linking this item to any <see cref="Outfit"/> entities it belongs to.</value>
        public ICollection<OutfitItem> OutfitItems { get; set; } = new List<OutfitItem>();
    }
}