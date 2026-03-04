using RestFlux.Application.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFlux.Application.Orders.Commands
{
    public record CreateOrderCommand
    (
        List<CreateOrderItemDto> Items
    );
}
