﻿using MultiShop.Order.Application.Features.CQRS.Queries.AdressQueries;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQeuries;
using MultiShop.Order.Application.Features.CQRS.Results.AdressResults;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailsResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
            OrderDetailId = values.OrderDetailId,
            ProductAmount= values.ProductAmount,
            ProductId = values.ProductId,
            ProductName = values.ProductName,
            OrderingId = values.OrderingId,
            ProductPrice = values.ProductPrice,
            ProductTotalPrice = values.ProductTotalPrice,
                    
        
            };
        }
    }
}
  