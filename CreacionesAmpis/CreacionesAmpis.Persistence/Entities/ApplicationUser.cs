using Microsoft.AspNetCore.Identity;
using CreacionesAmpis.Domain.Entities.Account;
namespace CreacionesAmpis.Persistence.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
