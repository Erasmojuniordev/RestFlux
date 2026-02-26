using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFlux.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name,decimal price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            Name = name;
            if (price < 0) throw new ArgumentException("Price cannot be negative.", nameof(price));
            Price = price;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentException("Price cannot be negative.", nameof(newPrice));
            Price = newPrice;
        }
    }
}
