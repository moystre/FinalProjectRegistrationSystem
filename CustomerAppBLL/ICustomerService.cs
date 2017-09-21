using CustomerAppBLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL
{
    public interface ICustomerService
    {
        //Create
        CustomerBO Create(CustomerBO cust);

        //Read
        List<CustomerBO> GetAll();
        CustomerBO Get(int Id);

        //Update
        CustomerBO Update(CustomerBO cust);

        //Delete
        CustomerBO Delete(int Id);
    }
}
