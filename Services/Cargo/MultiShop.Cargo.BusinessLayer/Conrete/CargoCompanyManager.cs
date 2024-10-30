using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Conrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyManager(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        public void TDelete(int id)
        {
           _cargoCompanyService.TDelete(id);
        }

        public List<CargoCompany> TGetAll()
        {
          return _cargoCompanyService.TGetAll();
        }

        public CargoCompany TGetById(int id)
        {
            return _cargoCompanyService.TGetById(id);
        }

        public void TInsert(CargoCompany entity)
        {
            _cargoCompanyService.TInsert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {
           _cargoCompanyService.TUpdate(entity);
        }
    }
}
