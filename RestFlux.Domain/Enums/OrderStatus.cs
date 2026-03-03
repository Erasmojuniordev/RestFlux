using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFlux.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 1,
        Paid = 2,
        Cancelled = 3,
        Delivered = 4,
        Completed = 5,  
    }
}
