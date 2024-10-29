﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers
{
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery,List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repositories;

        public GetOrderingQueryHandler(IRepository<Ordering> repositories)
        {
            _repositories = repositories;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repositories.GetAllAsync();
            return values.Select(x => new GetOrderingQueryResult
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId
            }).ToList();
        }

       
    }
}