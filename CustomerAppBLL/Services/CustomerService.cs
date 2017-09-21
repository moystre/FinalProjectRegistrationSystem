using System;
using System.Collections.Generic;
using CustomerAppDAL;
using System.Linq;
using CustomerAppDAL.Entities;
using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Converters;

namespace CustomerAppBLL.Services
{
    class CustomerService : ICustomerService
    {
        CustomerConverter conv = new CustomerConverter();
        AddressConverter aConv = new AddressConverter();

        DALFacade facade;

        public CustomerService(DALFacade facade)
        {
            //repo from class = repo from method
            this.facade = facade;
        }

        public CustomerBO Create(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newcust = uow.CustomerRepository.Create(conv.Convert(cust));
                uow.Complete();
                return conv.Convert(newcust);
            }
        }

        public void CreateAll(List<CustomerBO> customers)
        {
            using (var uow = facade.UnitOfWork)
            {
                foreach (var customer in customers)
                {
                    var newcust = uow.CustomerRepository.Create(conv.Convert(customer));
                }
                uow.Complete();
            }
        }

        public CustomerBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newcust = uow.CustomerRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newcust);
            }
        }

        public CustomerBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                //1. Get and convert customer
                var cust = conv.Convert(uow.CustomerRepository.Get(Id));

                //2. Get all related addresses
                //3. Convert and Add the Addresses to CustomerBO

                //cust.Addresses = cust.AddressIds?.Select(id => aConv.Convert(uow.AddressRepository.Get(id))).ToList();
                cust.Addresses = uow.AddressRepository.GetAllById(cust.AddressIds).Select(a => aConv.Convert(a)).ToList();

                //4. Return the Customer
                return cust;
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //Customer -> CustomerBO
                //return uow.CustomerRepository.GetAll();
                return uow.CustomerRepository.GetAll().Select(c => conv.Convert(c)).ToList();
            }
        }

        public CustomerBO Update(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.Get(cust.Id);
                if (customerFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }

                var customerUpdated = conv.Convert(cust);
                customerFromDb.FirstName = customerUpdated.FirstName;
                customerFromDb.LastName = customerUpdated.LastName;
                //customerFromDb.Addresses = customerUpdated.Addresses;

                //1. Remove all, except old ids
                customerFromDb.Addresses.RemoveAll(ca => !customerUpdated.Addresses.Exists(a => a.AddressId == ca.AddressId && a.CustomerId == ca.CustomerId));

                //2. Remove all ids that are already in the database
                customerUpdated.Addresses.RemoveAll(ca => customerFromDb.Addresses.Exists(a => a.AddressId == ca.AddressId && a.CustomerId == ca.CustomerId));

                //3. Add all new CustomerAddresses
                customerFromDb.Addresses.AddRange(customerUpdated.Addresses);

                uow.Complete();
                return conv.Convert(customerFromDb);
            }
        }
    }
}
