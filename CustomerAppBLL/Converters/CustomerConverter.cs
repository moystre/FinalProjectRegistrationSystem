﻿using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerAppBLL.Converters
{
    class CustomerConverter
    {
        private AddressConverter aConv;

        public CustomerConverter()
        {
            aConv = new AddressConverter();
        }
        internal Customer Convert(CustomerBO cust)
        {
            if (cust == null)
                return null;

            return new Customer()
            {
                Id = cust.Id,
                Addresses = cust.AddressIds?.Select(aId => new CustomerAddress()
                {
                    AddressId = aId,
                    CustomerId = cust.Id
                }).ToList(),
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }

        internal CustomerBO Convert(Customer cust)
        {
            if(cust == null) { return null; }
            return new CustomerBO()
            {
                Id = cust.Id,
                AddressIds = cust.Addresses?.Select(a => a.AddressId).ToList(),
                /*Addresses = cust.Addresses?.Select(a => new AddressBO()
                {
                    Id = a.CustomerId,
                    City = a.Address?.City,
                    Number = a.Address?.Number,
                    Street = a.Address?.Street
                }).ToList(),*/
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }
    }
}
