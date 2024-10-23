﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AdressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddAddressQueryHandler;
        private readonly GetAdressByIdQueryHandler _getAddAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAdressCommandHandler _updateAdressCommandHandler;
        private readonly RemoveAdressCommandHandler _removeAdressCommandHandler;

        public AddressController(GetAddressQueryHandler getAddAddressQueryHandler,
            GetAdressByIdQueryHandler getAddAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler,
            UpdateAdressCommandHandler updateAdressCommandHandler, RemoveAdressCommandHandler removeAdressCommandHandler)
        {
            _getAddAddressQueryHandler = getAddAddressQueryHandler;
            _getAddAddressByIdQueryHandler = getAddAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAdressCommandHandler = updateAdressCommandHandler;
            _removeAdressCommandHandler = removeAdressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = _getAddAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id )
        {
            var valuse=await _getAddAddressByIdQueryHandler.Handle(new GetAdressByIdQuery(id));

            return Ok(valuse);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Adres bilgisi başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdress(UpdateAddressCommand command)
        {
            await _updateAdressCommandHandler.Handle(command);
            return Ok("Address bilgisi başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            await _removeAdressCommandHandler.Handle(new RemoveAddressCommand(id));

            return Ok("Adress başarıya silindi");
        }

    }
}
