using RestFlux.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFlux.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        private List<OrderItem> _items = new List<OrderItem>();
        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
        public decimal TotalAmount { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Order()
        {
            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.Pending;
        }

        public void AddOrderItem(OrderItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (Status == OrderStatus.Delivered || Status == OrderStatus.Cancelled) throw new InvalidOperationException("Cannot add items to a delivered or canceled order.");
            _items.Add(item);

            TotalAmount += _items.Sum(i => i.TotalPrice);
        }

        // Metodos de validação para transições de status
        public void MarkAsPaid()
        {
            if (Status != OrderStatus.Pending) throw new InvalidOperationException("Only pending orders can be marked as paid.");
            Status = OrderStatus.Paid;
        }

        public void MarkAsCancelled()
        {
            if (Status == OrderStatus.Completed || Status == OrderStatus.Delivered) throw new InvalidOperationException("Completed orders cannot be canceled");
            Status = OrderStatus.Cancelled;
        }

        public void MarkAsDelivered()
        {
            if (Status != OrderStatus.Paid) throw new InvalidOperationException("Only paid orders can be marked as delivered.");
            Status = OrderStatus.Delivered;
        }

        public void MarkAsCompleted()
        {
            if (Status != OrderStatus.Delivered) throw new InvalidOperationException("Only delivered orders can be marked as completed.");
            Status = OrderStatus.Completed;
        }
    }
}
