// -----------------------------------------------------------------------
// <copyright file="IClothingItemService.cs" company="WardrobeApi">
//     Copyright (c) WardrobeApi. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Defines the contract for the clothing item service within the WardrobeApi application.
// </summary>

namespace WardrobeApi.Data.ServiceInterfaces
{
    using WardrobeApi.Data.Models;

    /// <summary>
    /// Represents the contract fo the clothing item service.
    /// </summary>
    public interface IClothingItemService
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