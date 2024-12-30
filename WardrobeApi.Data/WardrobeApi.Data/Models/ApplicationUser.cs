// -----------------------------------------------------------------------
// <copyright file="ApplicationUser.cs" company="WardrobeApi">
//     Copyright (c) WardrobeApi. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Defines the ApplicationUser entity, extending IdentityUser for authentication within the WardrobeApi application.
// </summary>

namespace WardrobeApi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// Represents a user in the WardrobeApi application, extending IdentityUser for authentication and authorization.
    /// </summary>
    public class ApplicationUser : IdentityUser<int>
    {
        /// <summary>
        /// Gets the date and time (in UTC) when this user was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets the date and time (in UTC) when this user was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

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
