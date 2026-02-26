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
    }
}
