using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL
{
    public interface IAddressRepository
    {
        Address Create(Address address);
        List<Address> GetAll();
        IEnumerable<Address> GetAllById(List<int> ids);
        Address Get(int Id);
        Address Delete(int Id);
    }
}
