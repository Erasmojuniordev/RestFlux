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
        public decimal TotalAmount => _items.Sum(i => i.TotalPrice);
        public OrderStatus Status { get; private set; }

        public Order()
        {
            Status = OrderStatus.Pending;
        }

        public void AddOrderItem(OrderItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (Status == OrderStatus.Delivered || Status == OrderStatus.Canceled) throw new InvalidOperationException("Cannot add items to a delivered or canceled order.");
            _items.Add(item);
        }

        public void StartPreparing()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidOperationException("Only pending orders can be started.");
            if (!_items.Any())
                throw new InvalidOperationException("Cannot start an order without items.");
            Status = OrderStatus.InProgress;
        }

        public void MarkAsReady()
        {
            if (Status != OrderStatus.InProgress)
                throw new InvalidOperationException("Only in-progress orders can be marked as ready.");
            Status = OrderStatus.Ready;
        }

        public void MarkAsDelivered()
        {
            if (Status != OrderStatus.Ready)
                throw new InvalidOperationException("Only ready orders can be marked as delivered.");
            Status = OrderStatus.Delivered;
        }

        public void MarkAsPaid()
        {
            if (Status != OrderStatus.Delivered)
                throw new InvalidOperationException("Only delivered orders can be marked as paid.");
            if (!_items.Any())
                throw new InvalidOperationException("Cannot pay an order without items.");
            Status = OrderStatus.Paid;
        }

        public void MarkAsCancelled()
        {
            if (Status == OrderStatus.Paid)
                throw new InvalidOperationException("Paid orders cannot be cancelled.");
            Status = OrderStatus.Cancelled;
        }
    }
}
