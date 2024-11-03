using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dto.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dto.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values=_cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address=createCargoCustomerDto.Address,
                City=createCargoCustomerDto.City,
                District=createCargoCustomerDto.District,
                Email=createCargoCustomerDto.Email,
                Name=createCargoCustomerDto.Name,
                Phone=createCargoCustomerDto.Phone,
                Surname=createCargoCustomerDto.Surname,
            };
            _cargoCustomerService.TInsert(cargoCustomer);

            return Ok("Kargo Müşteri Ekleme İşlemi Başarıyla Eklendi");

        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo Müşteri Silme İşlemi Başarıyla Yapıldı");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = updateCargoCustomerDto.Address,
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Phone = updateCargoCustomerDto.Phone,
                Surname = updateCargoCustomerDto.Surname,
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo Müşteri Güncelleme işlemi Başarıyla Yapıldı");
        }
    }
}
