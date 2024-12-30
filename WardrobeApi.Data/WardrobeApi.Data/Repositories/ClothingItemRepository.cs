// -----------------------------------------------------------------------
// <copyright file="ClothingItemRepository.cs" company="WardrobeApi">
//     Copyright (c) WardrobeApi. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Defines the instance of the clothing item repository.
// </summary>

namespace WardrobeApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using WardrobeApi.Data.Models;
    using WardrobeApi.Data.RepositoryInterfaces;

    /// <summary>
    /// The instance of the clothing item repository.
    /// </summary>
    public class ClothingItemRepository : IClothingItemRepository
    {
        /// <summary>
        /// The Wardrobe database context that acts as a bridge between the application and the database.
        /// </summary>
        private readonly WardrobeContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClothingItemRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ClothingItemRepository(WardrobeContext context)
        {
            this._context = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ClothingItem>> Get()
        {
            return await this._context.ClothingItems.ToListAsync<ClothingItem>();
        }

        /// <inheritdoc />
        public async Task<ClothingItem?> GetById(int id)
        {
            return await this._context.ClothingItems.FindAsync(id);
        }
    }
}