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
    using WardrobeApi.Data.Models;
    using WardrobeApi.Data.RepositoryInterfaces;
    using WardrobeApi.Data.ServiceInterfaces;

    /// <summary>
    /// Represents the business logic layer for clothing items.
    /// </summary>
    public class ClothingItemService : IClothingItemService
    {
        /// <summary>
        /// The instance of the item repository class.
        /// </summary>
        private readonly IClothingItemRepository _clothingItemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClothingItemService"/> class.
        /// </summary>
        /// <param name="clothingItemRepository">The clothing item repository.</param>
        public ClothingItemService(IClothingItemRepository clothingItemRepository)
        {
            this._clothingItemRepository = clothingItemRepository;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ClothingItem>> Get()
        {
            return await this._clothingItemRepository.Get();
        }

        /// <inheritdoc />
        public async Task<ClothingItem?> GetById(int id)
        {
            return await this._clothingItemRepository.GetById(id);
        }
    }
}