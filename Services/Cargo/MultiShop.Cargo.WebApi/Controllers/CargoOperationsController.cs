using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dto.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dto.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController: ControllerBase
    {
        private readonly ICargoOperationService _CargoOperationService;

        public CargoOperationController(ICargoOperationService CargoOperationService)
        {
            _CargoOperationService = CargoOperationService;
        }
        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _CargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation CargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description= createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
              

            };
            _CargoOperationService.TInsert(CargoOperation);

            return Ok("Kargo Müşteri Ekleme İşlemi Başarıyla Eklendi");

        }
        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _CargoOperationService.TDelete(id);
            return Ok("Kargo Müşteri Silme İşlemi Başarıyla Yapıldı");
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation CargoOperation = new CargoOperation()
            {
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate,
                CargoOperationId= updateCargoOperationDto.CargoOperationId,
            };
            _CargoOperationService.TUpdate(CargoOperation);
            return Ok("Kargo Müşteri Güncelleme işlemi Başarıyla Yapıldı");
        }
    }
}
