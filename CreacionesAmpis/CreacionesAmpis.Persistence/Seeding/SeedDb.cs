using CreacionesAmpis.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
namespace CreacionesAmpis.Persistence.Seeding
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public SeedDb(DataContext context, UserManager<ApplicationUser> userManager) { _context = context; _userManager = userManager; }
        public async Task SeedAsync()
        {
            await new CategoriesSeeder(_context).SeedAsync();
            await new PermissionsSeeder(_context).SeedAsync();
            await new UsersSeeder(_userManager, _context).SeedAsync();
        }
    }
}
