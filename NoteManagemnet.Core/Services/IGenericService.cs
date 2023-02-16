using NoteManagement.Core.Models;
using System.Linq.Expressions;

namespace NoteManagement.Core.Services
{
    public interface IGenericService<T> where T : class   
    {
        Task<T> GetByIdAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> Where(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    
    }
}
