using Microsoft.EntityFrameworkCore;
using CreacionesAmpis.Application.Contracts.Pagination;
namespace CreacionesAmpis.Persistence.Extensions
{
    internal static class QueryableExtensions
    {
        public static async Task<(List<T> items, int totalCount)> ToPagedListAsync<T>(this IQueryable<T> query,
            PaginationRequest request, CancellationToken cancellationToken = default)
        {
            int totalCount = await query.CountAsync(cancellationToken);
            List<T> items = await query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            return (items, totalCount);
        }
    }
}
