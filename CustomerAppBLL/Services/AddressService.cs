using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Converters;
using CustomerAppDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerAppBLL.Services
{
    public class AddressService : IAddressService
    {
        AddressConverter _conv;
        DALFacade _facade;

        public AddressService(DALFacade facade)
        {
            _facade = facade;
            _conv = new AddressConverter();
        }

        public AddressBO Create(AddressBO address)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newAddress = uow.AddressRepository.Create(_conv.Convert(address));
                uow.Complete();
                return _conv.Convert(newAddress);
            }
        }

        public void CreateAll(List<AddressBO> addresses)
        {
            using (var uow = _facade.UnitOfWork)
            {
                foreach (var address in addresses)
                {
                    var newAddress = uow.AddressRepository.Create(_conv.Convert(address));
                }
                uow.Complete();
            }
        }

        public AddressBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newAddress = uow.AddressRepository.Delete(Id);
                uow.Complete();
                return _conv.Convert(newAddress);
            }
        }

        public AddressBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return _conv.Convert(uow.AddressRepository.Get(Id));
            }
        }

        public List<AddressBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.AddressRepository.GetAll().Select(c => _conv.Convert(c)).ToList();
            }
        }

        public AddressBO Update(AddressBO address)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var addressFromDb = uow.AddressRepository.Get(address.Id);
                if (addressFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }

                addressFromDb.Id = address.Id;
                addressFromDb.City = address.City;
                addressFromDb.Street = address.Street;
                addressFromDb.Number = address.Number;
                //addressFromDb. = address.Addresses.Select(_aConv.Convert).ToList();
                uow.Complete();
                return _conv.Convert(addressFromDb);
            }
        }
}
}
