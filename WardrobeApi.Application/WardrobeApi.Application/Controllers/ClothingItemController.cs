namespace WardrobeApi.Application.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WardrobeApi.Data.Models;
    using WardrobeApi.Data.RepositoryInterfaces;

    [Route("api/v1/clothing-items")]
    [ApiController]
    public class ClothingItemController : ControllerBase
    {
        private readonly IClothingItemRepository _clothingItemRepository;

        public ClothingItemController(IClothingItemRepository clothingItemRepository)
        {
            this._clothingItemRepository = clothingItemRepository;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ClothingItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<ClothingItem>), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ClothingItem>>> Get()
        {
            // TODO: This endpoint should be refactored to GetAllByUserId after authentication has been implemented.
            var clothingItems = await this._clothingItemRepository.Get();

            if (!clothingItems.Any())
            {
                return this.NoContent();
            }

            return this.Ok(clothingItems);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ClothingItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClothingItem>> GetById(int id)
        {
            // Retrieve the item from the database
            var item = await this._clothingItemRepository.GetById(id);

            if (item is null)
            {
                return this.NotFound($"Item with id: {id} not found.");
            }

            // Return the item if found
            return this.Ok(item);
        }
    }
}
