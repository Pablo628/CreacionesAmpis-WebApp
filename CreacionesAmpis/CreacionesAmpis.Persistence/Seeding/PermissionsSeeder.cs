using CreacionesAmpis.Application.Contracts.Security;
using CreacionesAmpis.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;
using static CreacionesAmpis.Application.Contracts.Security.PermissionCodesCatalog;
namespace CreacionesAmpis.Persistence.Seeding
{
    public class PermissionsSeeder : ISeedable
    {
        private readonly DataContext _context;
        public PermissionsSeeder(DataContext context) { _context = context; }
        public async Task SeedAsync()
        {
            foreach (PermissionSeed permission in PermissionCodesCatalog.All)
            {
                if (await _context.Permissions.AnyAsync(p => p.Code == permission.Code)) continue;
                await _context.AddAsync(new Permission(permission.Code, permission.Description, permission.Module));
                await _context.SaveChangesAsync();
            }
        }
    }
}
