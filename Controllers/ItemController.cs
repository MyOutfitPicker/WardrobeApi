// -----------------------------------------------------------------------
// <copyright file="ItemController.cs" company="MyWardrobe">
//     Copyright (c) MyWardrobe. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Represents the entry point to the clothing item endpoint.
// </summary>
// -----------------------------------------------------------------------
namespace MyWardrobeApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyWardrobeApi.Data;
    using MyWardrobeApi.Models;
    using MyWardrobeApi.Models.Dtos;

    /// <summary>
    /// Controller for managing item-related operations.
    /// </summary>
    [Route("api/v1/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        /// <summary>
        /// The Wardrobe database context that acts as a bridge between the application and the database.
        /// </summary>
        private readonly WardrobeContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemController"/> class.
        /// </summary>
        /// <param name="context">The database context for the wardrobe.</param>
        public ItemController(WardrobeContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Creates a new item in the wardrobe.
        /// </summary>
        /// <param name="itemDto">The data transfer object containing the item details.</param>
        /// <returns>A 201 Created response with the new item, or a 400 Bad Request if the input is invalid.</returns>
        /// <response code="201">Indicates that the item was successfully created.</response>
        /// <response code="400">Indicates that the request was invalid.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Item>> Create([FromBody] ItemDto itemDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var item = new Item()
            {
                Name = itemDto.Name,
                Type = itemDto.Type,
                Color = itemDto.Color,
                Brand = itemDto.Brand,
                Size = itemDto.Size,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await this._context.Items.AddAsync(item);
            await this._context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(this.GetById), item);
        }

        /// <summary>
        /// Retrieves all items.
        /// </summary>
        /// <returns>The item collection if found and has items; otherwise, a 204 as no content.</returns>
        /// <response code="200">Returns the requested item list.</response>
        /// <response code="204">Returns the requested item list with no content.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Item>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<Item>), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<Item>>> GetAll()
        {
            // TODO: This endpoint should be refactored to GetAllByUserId after authentication has been implemented.
            var itemsList = await this._context.Items.ToListAsync();

            if (!itemsList.Any())
            {
                return this.NoContent();
            }

            return this.Ok(itemsList);
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
        [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Item>> GetById(int id)
        {
            // Retrieve the item from the database
            var item = await this._context.Items.FindAsync(id);

            if (id <= 0)
            {
                return this.BadRequest(new { Message = "The item ID must be a positive integer." });
            }

            if (item is null)
            {
                return this.NotFound(new { Message = $"Item with ID {id} not found." });
            }

            // Return the item if found
            return this.Ok(item);
        }
    }
}
