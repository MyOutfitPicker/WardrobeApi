// -----------------------------------------------------------------------
// <copyright file="ClothingItemDto.cs" company="WardrobeApi">
//     Copyright (c) WardrobeApi. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Defines the ItemDto, which represents a single clothing or accessory item
//     within the WardrobeApi application.
// </summary>

namespace WardrobeApi.Data.Models.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using WardrobeApi.Shared.Enums;

    /// <summary>
    /// Represents a single clothing or accessory item data transfer object in the wardrobe.
    /// </summary>
    public class ClothingItemDto
    {
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
    }
}
