// -----------------------------------------------------------------------
// <copyright file="OutfitItem.cs" company="MyWardrobe">
//     Copyright (c) MyWardrobe. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Defines the OutfitItem entity, representing the many-to-many relationship
//     between Outfits and Items in the MyWardrobe application.
// </summary>
namespace MyWardrobeApi.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents the association between an outfit and an item, forming a many-to-many relationship.
    /// </summary>
    [Keyless]
    public class OutfitItem
    {
        /// <summary>
        /// Gets or sets the unique identifier of the outfit linked to this record.
        /// </summary>
        /// <value>
        /// An integer representing the primary key of the associated outfit in the <see cref="Outfit"/> table.
        /// </value>
        [ForeignKey("Outfit")]
        [Required]
        public int OutfitId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Outfit"/> object linked to this record.
        /// </summary>
        /// <value>
        /// A navigation property to the <see cref="Outfit"/> entity that this association belongs to.
        /// </value>
        public Outfit Outfit { get; set; } = default!;

        /// <summary>
        /// Gets or sets the unique identifier of the item linked to this record.
        /// </summary>
        /// <value>
        /// A string representing the primary key of the associated item in the <see cref="Item"/> table.
        /// </value>
        [ForeignKey("Item")]
        [Required]
        public int ItemId { get; set; } = default!;

        /// <summary>
        /// Gets or sets the <see cref="Item"/> object linked to this record.
        /// </summary>
        /// <value>
        /// A navigation property to the <see cref="Item"/> entity that this association refers to.
        /// </value>
        public Item Item { get; set; } = default!;
    }
}