using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFlux.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 0,
        SentToKitchen = 1,
        InPreparation = 2,
        Ready = 3,
        Delivered = 4,
        Canceled = 5
    }
}
