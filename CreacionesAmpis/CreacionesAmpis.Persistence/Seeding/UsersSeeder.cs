using CreacionesAmpis.Application.Contracts.Security;
using CreacionesAmpis.Domain.Entities.Account;
using CreacionesAmpis.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace CreacionesAmpis.Persistence.Seeding
{
    public class UsersSeeder
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _context;
        public UsersSeeder(UserManager<ApplicationUser> userManager, DataContext context) { _userManager = userManager; _context = context; }
        public async Task SeedAsync() { await SeedRolesAsync(); await SeedUsersAsync(); }
        private async Task SeedUsersAsync()
        {
            await CheckUsersAsync("admin@creacionesampis.com", "Admin", "Ampis", RolesCatalog.ADMIN);
            await CheckUsersAsync("cliente@creacionesampis.com", "Cliente", "Demo", RolesCatalog.USER);
        }
        private async Task SeedRolesAsync()
        {
            await CheckRolesAsync(RolesCatalog.ADMIN, PermissionCodesCatalog.AllCodes.ToList());
            await CheckRolesAsync(RolesCatalog.STORE_MANAGER, new List<string> { PermissionCodesCatalog.SHOW_PRODUCTS, PermissionCodesCatalog.CREATE_PRODUCTS, PermissionCodesCatalog.EDIT_PRODUCTS, PermissionCodesCatalog.SHOW_CATEGORIES, PermissionCodesCatalog.CREATE_CATEGORIES });
            await CheckRolesAsync(RolesCatalog.USER, new List<string> { PermissionCodesCatalog.SHOW_PRODUCTS, PermissionCodesCatalog.SHOW_CATEGORIES });
        }
        private async Task CheckUsersAsync(string email, string firstName, string lastName, string roleName)
        {
            Role role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
            if (await _userManager.FindByEmailAsync(email) is null)
                await _userManager.CreateAsync(new ApplicationUser { UserName = email, Email = email, EmailConfirmed = true, FirstName = firstName, LastName = lastName, RoleId = role.Id }, "1234");
        }
        private async Task CheckRolesAsync(string roleName, List<string> permissionCodes)
        {
            Role? role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
            if (role is null) { role = new Role(roleName); await _context.Roles.AddAsync(role); await _context.SaveChangesAsync(); }
            List<Guid> permissionIds = await _context.Permissions.Where(p => permissionCodes.Contains(p.Code)).Select(p => p.Id).ToListAsync();
            List<Guid> existing = await _context.RolePermissions.Where(rp => rp.RoleId == role.Id).Select(rp => rp.PermissionId).ToListAsync();
            foreach (Guid permissionId in permissionIds.Except(existing))
                await _context.RolePermissions.AddAsync(new RolePermission(role.Id, permissionId));
            await _context.SaveChangesAsync();
        }
    }
}
