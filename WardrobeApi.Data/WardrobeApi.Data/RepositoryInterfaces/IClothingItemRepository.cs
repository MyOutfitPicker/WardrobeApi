// -----------------------------------------------------------------------
// <copyright file="IClothingItemRepository.cs" company="WardrobeApi">
//     Copyright (c) WardrobeApi. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Defines the contract for the clothing item repository within the WardrobeApi application.
// </summary>

namespace WardrobeApi.Data.RepositoryInterfaces
{
    using WardrobeApi.Data.Models;

    /// <summary>
    /// The interface for the clothing item repository.
    /// </summary>
    public interface IClothingItemRepository
    {
        /// <summary>
        /// Retrieves all clothing items.
        /// </summary>
        /// <returns>The clothing item collection.</returns>
        Task<IEnumerable<ClothingItem>> Get();

        /// <summary>
        /// Retrieves an item by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the item.</param>
        /// <returns>The <see cref="ClothingItem"/> if found; otherwise null.</returns>
        Task<ClothingItem?> GetById(int id);
    }
}