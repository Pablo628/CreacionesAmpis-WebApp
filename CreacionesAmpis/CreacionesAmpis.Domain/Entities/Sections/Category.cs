using System;
using System.Collections.Generic;
using System.Text;
using CreacionesAmpis.Domain.Exceptions.PrivateBlog.Domain.Exceptions;

namespace CreacionesAmpis.Domain.Entities.Sections
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<Product> Products { get; private set; } = new List<Product>();

        public Category(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Category name cannot be empty");

            if (name.Length > 50)
                throw new DomainException("Category name cannot exceed 50 characters");

            Name = name;
        }
    }
}
