using CreacionesAmpis.Application.Contracts.Persistence;
namespace CreacionesAmpis.Persistence.UnitOfWorks
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public EfCoreUnitOfWork(DataContext context) { _context = context; }
        public async Task CommitAsync() => await _context.SaveChangesAsync();
        public Task RollbackAsync() => Task.CompletedTask;
    }
}
