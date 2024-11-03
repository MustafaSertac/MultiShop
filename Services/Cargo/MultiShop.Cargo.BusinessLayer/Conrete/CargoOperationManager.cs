using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Conrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public void TDelete(int id)
        {
            _cargoOperationDal.TDelete(id);
        }

        public List<CargoOperation> TGetAll()
        {
          return  _cargoOperationDal.TGetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return _cargoOperationDal.TGetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
            _cargoOperationDal.TInsert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            _cargoOperationDal.TUpdate(entity);
        }
    }
}
