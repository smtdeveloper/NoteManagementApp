using Microsoft.EntityFrameworkCore;
using NoteManagement.Core.Repositories;
using System.Linq.Expressions;

namespace NoteManagement.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<ICollection<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public void Remove(T entity) => _dbSet.Remove(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public async Task<ICollection<T>> Where(Expression<Func<T, bool>> expression) => await _dbSet.Where(expression).ToListAsync();

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

    }
}
