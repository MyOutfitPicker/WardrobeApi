// -----------------------------------------------------------------------
// <copyright file="ClothingItemController.cs" company="WardrobeApi">
//     Copyright (c) WardrobeApi. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Represents the entry point to the clothing item endpoint.
// </summary>
// -----------------------------------------------------------------------

namespace WardrobeApi.Application.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WardrobeApi.Data.Models;
    using WardrobeApi.Data.ServiceInterfaces;

    /// <summary>
    /// Controller for managing item-related operations.
    /// </summary>
    [Route("api/v1/clothing-items")]
    [ApiController]
    public class ClothingItemController : ControllerBase
    {
        /// <summary>
        /// The clothing item service used for the business layer.
        /// </summary>
        private readonly IClothingItemService _clothingItemService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClothingItemController"/> class.
        /// </summary>
        /// <param name="clothingItemService">The business layer object for the clothing item.</param>
        public ClothingItemController(IClothingItemService clothingItemService)
        {
            this._clothingItemService = clothingItemService;
        }

        /// <summary>
        /// Retrieves all items.
        /// </summary>
        /// <returns>The item collection if found and has items; otherwise, a 204 as no content.</returns>
        /// <response code="200">Returns the requested item list.</response>
        /// <response code="204">Returns the requested item list with no content.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ClothingItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<ClothingItem>), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ClothingItem>>> Get()
        {
            // TODO: This endpoint should be refactored to GetAllByUserId after authentication has been implemented.
            var clothingItems = await this._clothingItemService.Get();

            if (!clothingItems.Any())
            {
                return this.NoContent();
            }

            return this.Ok(clothingItems);
        }

        /// <summary>
        /// Retrieves an item by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the item.</param>
        /// <returns>The item if found; otherwise, a 404 error.</returns>
        /// <response code="200">Returns the requested item.</response>
        /// <response code="404">If the item is not found.</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ClothingItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClothingItem>> GetById(int id)
        {
            // Retrieve the item from the database
            var item = await this._clothingItemService.GetById(id);

            if (item is null)
            {
                return this.NotFound($"Item with id: {id} not found.");
            }

            // Return the item if found
            return this.Ok(item);
        }
    }
}
