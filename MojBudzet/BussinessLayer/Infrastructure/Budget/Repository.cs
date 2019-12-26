namespace MojBudzet.BussinessLayer.Infrastructure.Budget
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface Repository<T>
    {
        Task AddAsync(T item);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
    }
}
