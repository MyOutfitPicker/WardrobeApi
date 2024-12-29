// -----------------------------------------------------------------------
// <copyright file="Outfit.cs" company="WardrobeApi">
//     Copyright (c) WardrobeApi. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Defines the Outfit entity, representing a collection of items
//     under the WardrobeApi application.
// </summary>

namespace WardrobeApi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents an outfit in the wardrobe.
    /// </summary>
    public class Outfit
    {
        /// <summary>
        /// Gets or sets the unique identifier for this outfit.
        /// </summary>
        /// <value>An integer representing the primary key of the outfit record.</value>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the outfit (e.g., "Casual Friday").
        /// </summary>
        /// <value>A human-readable string describing the outfit.</value>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Gets or sets the ID of the user who created this outfit.
        /// </summary>
        /// <value>An integer referencing the user entity in the database.</value>
        [ForeignKey("ApplicationUser")]
        [Required]
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="User"/> object that created this outfit.
        /// </summary>
        /// <value>A navigation property to the user who owns or created the outfit.</value>
        public ApplicationUser CreatedByUser { get; set; } = default!;

        /// <summary>
        /// Gets or sets a value indicating whether the outfit is publicly visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if the outfit is publicly visible; otherwise, <c>false</c>.
        /// </value>
        [Required]
        public bool IsPublic { get; set; } = true;

        /// <summary>
        /// Gets or sets the date and time (in UTC) when this outfit was created.
        /// </summary>
        /// <value>A <see cref="DateTime"/> indicating the creation timestamp in UTC.</value>
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the date and time (in UTC) when this outfit was last updated.
        /// </summary>
        /// <value>A <see cref="DateTime"/> indicating the last update timestamp in UTC.</value>
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the collection of items that compose this outfit.
        /// </summary>
        /// <value>
        /// A collection of <see cref="OutfitItem"/> that links this outfit
        /// to one or more <see cref="Item"/> entities.
        /// </value>ßßß
        public ICollection<OutfitItem> OutfitItems { get; set; } = new List<OutfitItem>();
    }
}