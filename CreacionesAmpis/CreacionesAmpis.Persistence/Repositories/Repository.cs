using Microsoft.EntityFrameworkCore;
using CreacionesAmpis.Application.Contracts.Repositories;
namespace CreacionesAmpis.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        public Repository(DataContext context) { _context = context; }
        public Task<T> CreateAsync(T entity) { _context.Add(entity); return Task.FromResult(entity); }
        public Task DeleteAsync(T entity) { _context.Remove(entity); return Task.FromResult(entity); }
        public async Task<T?> GetByIdAsync(Guid id) => await _context.FindAsync<T>(id);
        public async Task<IEnumerable<T>> GetListAsync() => await _context.Set<T>().ToListAsync();
        public Task UpdateAsync(T entity) { _context.Update(entity); return Task.FromResult(entity); }
    }
}
