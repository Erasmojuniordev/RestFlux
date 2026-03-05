
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
        public decimal TotalPrice { get; private set; }

        public OrderItem(Product product, int quantity)
        {
            if (product.Id <= 0) throw new ArgumentException("ProductId must be greater than zero.", nameof(product.Id));
            ProductId = product.Id;
            if (string.IsNullOrWhiteSpace(product.Name)) throw new ArgumentException("ProductName cannot be null or empty.", nameof(product.Name));
            ProductName = product.Name;
            if (product.Price < 0) throw new ArgumentException("UnitPrice cannot be negative.", nameof(product.Price));
            UnitPrice = product.Price;
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            Quantity = quantity;

            TotalPrice = UnitPrice * quantity;
        }

        public void ChangeItemQuantity(int newQuantity)
        {
            Quantity = newQuantity;

            TotalPrice = UnitPrice * newQuantity;
        }

        private OrderItem() { } // EF Core retornar este construtor sem executar o calculo de TotalPrice
    }
}
