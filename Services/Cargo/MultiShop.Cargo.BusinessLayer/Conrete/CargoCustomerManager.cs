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
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public void TDelete(int id)
        {
            _cargoCustomerDal.TDelete(id);
        }

        public List<CargoCustomer> TGetAll()
        {
            return _cargoCustomerDal.TGetAll();
        }

        public CargoCustomer TGetById(int id)
        {
           return _cargoCustomerDal.TGetById(id);
        }

        public void TInsert(CargoCustomer entity)
        {
            _cargoCustomerDal.TInsert(entity);
        }

        public void TUpdate(CargoCustomer entity)
        {
            _cargoCustomerDal.TUpdate(entity);
        }
    }
}
