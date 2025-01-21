namespace WardrobeApi.Data.RepositoryInterfaces
{
    using WardrobeApi.Data.Models;

    public interface IClothingItemRepository
    {
        Task<IEnumerable<ClothingItem>> Get();

        Task<ClothingItem?> GetById(int id);
    }
}