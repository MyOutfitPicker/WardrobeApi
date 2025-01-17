// -----------------------------------------------------------------------
// <copyright file="IBaseRepository.cs" company="WardrobeApi">
//     Copyright (c) WardrobeApi. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Defines the contract for the base repository within the WardrobeApi application.
// </summary>
namespace WardrobeApi.Data.RepositoryInterfaces
{
    /// <summary>
    /// Defines a base repository interface for CRUD operations on entities.
    /// </summary>
    /// <typeparam name="T">The type of the entity this repository handles.</typeparam>
    internal interface IBaseRepository<T>
        where T : class
    {
        /// <summary>
        /// Retrieves <see cref="T"/> entity by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of <see cref="T"/> entity.</param>
        /// <returns>The <see cref="T"/> entity if found; otherwise null.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves a collection of <see cref="T"/> entity asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task" /> representing an asynchronous operation.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Adds <see cref="T"/> entity asynchronously.
        /// </summary>
        /// /// <returns>A <see cref="Task" /> representing an asynchronous operation.</returns>
        Task AddAsync();

        /// <summary>
        /// Deletes <see cref="T"/> entity asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of <see cref="T"/> entity.</param>
        /// <returns>A <see cref="Task" /> representing an asynchronous operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Updates <see cref="T"/> entity asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of <see cref="T"/> entity.</param>
        /// <returns>A <see cref="Task" /> representing an asynchronous operation.</returns>
        Task UpdateAsync(int id);
    }
}