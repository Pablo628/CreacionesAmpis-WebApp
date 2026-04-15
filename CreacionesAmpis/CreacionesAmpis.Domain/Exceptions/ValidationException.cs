namespace CreacionesAmpis.Domain.Exceptions
{
    public class ValidationException : DomainException
    {
        public IReadOnlyList<string> Errors { get; }

        public ValidationException(string message)
            : base(message)
        {
            Errors = new List<string> { message };
        }

        public ValidationException(IEnumerable<string> errors)
            : base("Se encontraron uno o más errores de validación.")
        {
            Errors = errors.ToList().AsReadOnly();
        }
    }
}
