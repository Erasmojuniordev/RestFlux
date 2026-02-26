
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFlux.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public string ProductName { get; private set; } // snapshot
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        public OrderItem(int productId, string productName, decimal unitPrice, int quantity)
        {
            if (productId <= 0) throw new ArgumentException("ProductId must be greater than zero.", nameof(productId));
            ProductId = productId;
            if (string.IsNullOrWhiteSpace(productName)) throw new ArgumentException("ProductName cannot be null or empty.", nameof(productName));
            ProductName = productName;
            if (unitPrice < 0) throw new ArgumentException("UnitPrice cannot be negative.", nameof(unitPrice));
            UnitPrice = unitPrice;
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            Quantity = quantity;
        }
    }
}
