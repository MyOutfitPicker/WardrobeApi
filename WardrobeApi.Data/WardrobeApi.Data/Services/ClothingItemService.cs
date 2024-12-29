// -----------------------------------------------------------------------
// <copyright file="ClothingItemService.cs" company="WardrobeApi">
//     Copyright (c) WardrobeApi. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Defines the contract for the clothing item service within the WardrobeApi application.
// </summary>

namespace WardrobeApi.Data.Services
{
    using Microsoft.EntityFrameworkCore;
    using WardrobeApi.Data;
    using WardrobeApi.Data.Models;
    using WardrobeApi.Data.ServiceInterfaces;

    /// <summary>
    /// Represents the business logic layer for clothing items.
    /// </summary>
    public class ClothingItemService : IClothingItemService
    {
        /// <summary>
        /// The Wardrobe database context that acts as a bridge between the application and the database.
        /// </summary>
        private readonly WardrobeContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClothingItemService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ClothingItemService(WardrobeContext context)
        {
            this._context = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ClothingItem>> Get()
        {
            return await this._context.ClothingItems.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<ClothingItem?> GetById(int id)
        {
            return await this._context.ClothingItems.FindAsync(id) ?? null;
        }
    }
}