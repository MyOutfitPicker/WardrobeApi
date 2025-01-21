namespace WardrobeApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using WardrobeApi.Data.Models;
    using WardrobeApi.Data.RepositoryInterfaces;

    public class ClothingItemRepository : IClothingItemRepository
    {
        private readonly WardrobeContext _context;

        public ClothingItemRepository(WardrobeContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<ClothingItem>> Get()
        {
            return await this._context.ClothingItems.ToListAsync<ClothingItem>();
        }

        public async Task<ClothingItem?> GetById(int id)
        {
            return await this._context.ClothingItems.FindAsync(id);
        }
    }
}