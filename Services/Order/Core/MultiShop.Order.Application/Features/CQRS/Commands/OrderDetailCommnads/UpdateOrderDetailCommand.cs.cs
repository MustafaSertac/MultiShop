using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommnads
{
    public class UpdateOrderDetailCommand
    {
        public int Id { get; set; }

        public UpdateOrderDetailCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
