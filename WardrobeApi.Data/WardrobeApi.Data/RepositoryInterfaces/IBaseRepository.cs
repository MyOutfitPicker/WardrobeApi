namespace WardrobeApi.Data.RepositoryInterfaces
{
    internal interface IBaseRepository<T>
        where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync();

        Task DeleteAsync(int id);

        Task UpdateAsync(int id);
    }
}