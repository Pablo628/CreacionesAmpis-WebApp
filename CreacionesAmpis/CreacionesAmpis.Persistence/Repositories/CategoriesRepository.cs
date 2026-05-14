using Microsoft.EntityFrameworkCore;
using CreacionesAmpis.Application.Contracts.Pagination;
using CreacionesAmpis.Application.Contracts.Repositories;
using CreacionesAmpis.Domain.Entities.Sections;
using CreacionesAmpis.Persistence.Extensions;
namespace CreacionesAmpis.Persistence.Repositories
{
    public class CategoriesRepository : Repository<Category>, ICategoriesRepository
    {
        private readonly DataContext _context;
        public CategoriesRepository(DataContext context) : base(context) { _context = context; }
        public async Task<(List<Category> items, int totalCount)> GetPagedList(PaginationRequest request,
            string? nameFilter, bool? isActiveFilter, CancellationToken cancellationToken = default)
        {
            IQueryable<Category> query = _context.Categories.AsQueryable();
            if (!string.IsNullOrWhiteSpace(nameFilter)) query = query.Where(c => c.Name.Contains(nameFilter.Trim()));
            if (isActiveFilter.HasValue) query = query.Where(c => c.IsActive == isActiveFilter.Value);
            return await query.OrderBy(c => c.Name).ToPagedListAsync(request, cancellationToken);
        }
        public async Task<bool> HasProductsAsync(Guid id) => await _context.Products.AnyAsync(p => p.CategoryId == id);
    }
}
