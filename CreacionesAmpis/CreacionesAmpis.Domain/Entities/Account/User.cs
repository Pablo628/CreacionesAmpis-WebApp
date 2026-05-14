using CreacionesAmpis.Domain.Exceptions;

namespace CreacionesAmpis.Domain.Entities.Account
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid RoleId { get; set; }

        private User() { }

        public static User Reconstitute(string id, string firstName, string lastName,
            string userName, string email, bool emailConfirmed, string? phoneNumber, Guid roleId)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new BussinesRuleException("El id es requerido.");
            if (string.IsNullOrWhiteSpace(firstName)) throw new BussinesRuleException("El nombre es requerido.");
            if (string.IsNullOrWhiteSpace(lastName)) throw new BussinesRuleException("El apellido es requerido.");
            if (string.IsNullOrWhiteSpace(email)) throw new BussinesRuleException("El correo electrónico es requerido.");
            if (roleId == Guid.Empty) throw new BussinesRuleException("El rol es requerido.");

            return new User { Id = id, FirstName = firstName, LastName = lastName, UserName = userName,
                              Email = email, EmailConfirmed = emailConfirmed, PhoneNumber = phoneNumber, RoleId = roleId };
        }
    }
}
