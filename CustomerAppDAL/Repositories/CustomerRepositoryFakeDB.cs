using CustomerAppDAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CustomerAppDAL.Repositories
{
    class CustomerRepositoryFakeDB : ICustomerRepository
    {

        private static int Id = 1;
        private static List<Customer> Customers = new List<Customer>();

        public Customer Create(Customer cust)
        {
            Customer newCust;
            Customers.Add(newCust = new Customer()
            {
                Id = Id++,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Addresses = cust.Addresses
            });

            return newCust;
        }

        public Customer Delete(int Id)
        {
            //Does not throw exception, returns customer or null
            var cust = Get(Id);

            //Throws exception if not found
            //var cust = FakeDB.Customers.First(x => x.Id == Id);
            //List all customers with that id
            //var cust = FakeDB.Customers.Where(x => x.Id == Id).ToList();

            Customers.Remove(cust);
            return cust;
        }

        public Customer Get(int Id)
        {
            return Customers.FirstOrDefault(x => x.Id == Id);
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(Customers);
        }
    }
}
