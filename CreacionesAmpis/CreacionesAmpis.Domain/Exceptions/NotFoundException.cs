namespace CreacionesAmpis.Domain.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string entityName, Guid id)
            : base($"{entityName} con Id '{id}' no fue encontrado.")
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
