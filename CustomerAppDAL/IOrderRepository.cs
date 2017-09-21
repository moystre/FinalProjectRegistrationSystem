using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL
{
    public interface IOrderRepository
    {
        Order Create(Order order);

        List<Order> GetAll();
        Order Get(int Id);

        Order Delete(int Id);
    }
}
