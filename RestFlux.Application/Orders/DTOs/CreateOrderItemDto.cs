using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFlux.Application.Orders.DTOs
{
    public record CreateOrderItemDto
    (
        int ProductId,
        int Quantity
    );
}
