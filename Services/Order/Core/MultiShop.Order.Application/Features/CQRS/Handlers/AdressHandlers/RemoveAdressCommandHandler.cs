using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class RemoveAdressCommandHandler
    {
        private readonly IRepository<Address>_respository;

        public RemoveAdressCommandHandler(IRepository<Address> respository)
        {
            _respository = respository;
        }
        public async Task Handle(RemoveAddressCommand command)
        {
            var value =await _respository.GetByIdAsync(command.Id);
            await _respository.DeleteAsync(value);

        }
    }
}
