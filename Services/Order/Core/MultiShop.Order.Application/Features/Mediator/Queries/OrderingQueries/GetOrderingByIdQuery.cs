using MediatR;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailsResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery:IRequest<GetOrderDetailByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderingByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
