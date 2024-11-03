using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dto.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dto.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _CargoDetailService;

        public CargoDetailController(ICargoDetailService CargoDetailService)
        {
            _CargoDetailService = CargoDetailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _CargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId=createCargoDetailDto.CargoCompanyId,
                ReceiverCustomer=createCargoDetailDto.ReceiverCustomer,
                SenderCustomer=createCargoDetailDto.SenderCustomer,
                
            };
            _CargoDetailService.TInsert(CargoDetail);

            return Ok("Kargo Müşteri Ekleme İşlemi Başarıyla Eklendi");

        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _CargoDetailService.TDelete(id);
            return Ok("Kargo Müşteri Silme İşlemi Başarıyla Yapıldı");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
            };
            _CargoDetailService.TUpdate(CargoDetail);
            return Ok("Kargo Müşteri Güncelleme işlemi Başarıyla Yapıldı");
        }
    }
}
