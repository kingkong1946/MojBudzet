namespace MojBudzet.BussinessLayer.Infrastructure.Budget
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Generic repository.
    /// </summary>
    /// <typeparam name="T">Generic parametr. See more information <typeparamref name="T"/>.</typeparam>
    public interface Repository<T>
    {
        /// <summary>
        /// Adds item to repository.
        /// </summary>
        /// <param name="item">Item to persist.</param>
        /// <returns><typeparamref name="T"/>.</returns>
        Task AddAsync(T item);

        /// <summary>
        /// Finding item in repository.
        /// </summary>
        /// <param name="predicate">An object search predicate.</param>
        /// <returns>Searched item See more information <typeparamref name="T"/>.</returns>
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
