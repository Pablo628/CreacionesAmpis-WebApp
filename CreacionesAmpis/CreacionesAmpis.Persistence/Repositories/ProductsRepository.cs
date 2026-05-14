using Microsoft.EntityFrameworkCore;
using CreacionesAmpis.Application.Contracts.Pagination;
using CreacionesAmpis.Application.Contracts.Repositories;
using CreacionesAmpis.Domain.Entities.Sections;
using CreacionesAmpis.Persistence.Extensions;
namespace CreacionesAmpis.Persistence.Repositories
{
    public class ProductsRepository : Repository<Product>, IProductsRepository
    {
        private readonly DataContext _context;
        public ProductsRepository(DataContext context) : base(context) { _context = context; }
        public async Task<Product?> GetByIdWithCategoryAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _context.Set<Product>().Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        public async Task<(List<Product> items, int totalCount)> GetPagedListAsync(PaginationRequest request,
            string? filter, Guid? categoryIdFilter, CancellationToken cancellationToken = default)
        {
            IQueryable<Product> query = _context.Set<Product>().Include(p => p.Category).AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter)) query = query.Where(p => p.Name.Contains(filter.Trim()));
            if (categoryIdFilter.HasValue) query = query.Where(p => p.CategoryId == categoryIdFilter.Value);
            return await query.OrderByDescending(p => p.CreatedAt).ToPagedListAsync(request, cancellationToken);
        }
    }
}
