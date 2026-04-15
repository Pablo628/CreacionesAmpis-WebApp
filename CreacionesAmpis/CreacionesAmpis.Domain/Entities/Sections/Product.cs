using CreacionesAmpis.Domain.Exceptions.PrivateBlog.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreacionesAmpis.Domain.Entities.Sections
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public bool IsCustomizable { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public Product(string name, string description, decimal price, int categoryId)
        {
            SetName(name);
            SetDescription(description);
            SetPrice(price);
            CategoryId = categoryId;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Product name cannot be empty");

            if (name.Length > 100)
                throw new DomainException("Product name cannot exceed 100 characters");

            Name = name;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description cannot be empty");

            Description = description;
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new DomainException("Price must be greater than zero");

            Price = price;
        }

        public void SetCustomizable(bool value)
        {
            IsCustomizable = value;
        }
    }
}
