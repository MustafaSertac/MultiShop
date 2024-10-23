using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommnads;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQeuries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailQueryHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailQueryHandler;

        public OrderDetailController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, 
            GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
            RemoveOrderDetailCommandHandler removeOrderDetailQueryHandler, UpdateOrderDetailCommandHandler updateOrderDetailQueryHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _removeOrderDetailQueryHandler = removeOrderDetailQueryHandler;
            _updateOrderDetailQueryHandler = updateOrderDetailQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("[id]")]

        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var values = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş detayı başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id )
        {
            await _removeOrderDetailQueryHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Sipariş detayı  başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailQueryHandler.Handle(command);
            return Ok("Sipariş detayı başarıyla güncellendi");
        }
    }

}
