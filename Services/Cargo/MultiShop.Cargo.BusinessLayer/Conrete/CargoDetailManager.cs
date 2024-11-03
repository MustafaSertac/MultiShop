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
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal= cargoDetailDal;
        }

        public void TDelete(int id)
        {
            _cargoDetailDal.TDelete(id);
        }

        public List<CargoDetail> TGetAll()
        {
            return _cargoDetailDal.TGetAll();
        }

        public CargoDetail TGetById(int id)
        {
           return _cargoDetailDal.TGetById(id);
        }

        public void TInsert(CargoDetail entity)
        {
           _cargoDetailDal.TInsert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
           _cargoDetailDal.TUpdate(entity);
        }
    }
}
