using CustomerAppDAL.Context;
using CustomerAppDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; internal set; }
        public IOrderRepository OrderRepository { get; internal set; }
        public IAddressRepository AddressRepository { get; internal set; }

        private CustomerAppContext context;

        public UnitOfWork()
        {
            context = new CustomerAppContext();
            context.Database.EnsureCreated();
            CustomerRepository = new CustomerRepository(context);
            OrderRepository = new OrderRepository(context);
            AddressRepository = new AddressRepository(context);
        }

        public int Complete()
        {
            //Number of objects written to the database
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
