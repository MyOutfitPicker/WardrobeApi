namespace MyWardrobeApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MyWardrobeApi.Data;
    using MyWardrobeApi.Models;
    using MyWardrobeApi.Models.Dtos;

    /// <summary>
    /// Controller for managing item-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
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

            return this.CreatedAtAction(nameof(this.GetItemById), item);
        }

        /// <summary>
        /// Retrieves an item by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the item.</param>
        /// <returns>The item if found; otherwise, a 404 error.</returns>
        /// <response code="200">Returns the requested item.</response>
        /// <response code="404">If the item is not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
            // Retrieve the item from the database
            var item = await this._context.Items.FindAsync(id);

            if (item is null)
            {
                // Return 404 if the item is not found
                return this.NotFound(new { Message = $"Item with ID {id} not found." });
            }

            // Return the item if found
            return this.Ok(item);
        }
    }
}
