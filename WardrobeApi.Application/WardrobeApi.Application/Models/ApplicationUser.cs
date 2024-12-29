// -----------------------------------------------------------------------
// <copyright file="ApplicationUser.cs" company="MyWardrobe">
//     Copyright (c) MyWardrobe. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Defines the ApplicationUser entity, extending IdentityUser for authentication within the MyWardrobe application.
// </summary>

namespace MyWardrobeApi.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// Represents a user in the MyWardrobe application, extending IdentityUser for authentication and authorization.
    /// </summary>
    public class ApplicationUser : IdentityUser<int>
    {
        /// <summary>
        /// Gets or sets the date and time (in UTC) when this user was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the date and time (in UTC) when this user was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the collection of outfits created by this user.
        /// </summary>
        public ICollection<Outfit> Outfits { get; set; } = new List<Outfit>();

        /// <summary>
        /// Gets or sets the collection of items created by this user.
        /// </summary>
        public ICollection<ClothingItem> ClothingItems { get; set; } = new List<ClothingItem>();
    }
}
