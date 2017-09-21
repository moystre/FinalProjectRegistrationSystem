using CustomerAppBLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL
{
    public interface IOrderService
    {
        OrderBO Create(OrderBO order);
        List<OrderBO> GetAll();
        OrderBO Get(int Id);
        OrderBO Update(OrderBO order);
        OrderBO Delete(int Id);
    }
}
