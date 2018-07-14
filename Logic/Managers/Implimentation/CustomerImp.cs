using System;
using System.Collections.Generic;
using Logic.DTO;
using Logic.Managers.Interfaces;
using Storage.Models;

namespace Logic.Managers.Implimentation
{
    class CustomerImp : ICustomer
    {
        private readonly Context db;
        Customer Customer;

        public CustomerDTO GetInfo(int id)
        {
            Customer = db.Customer.Find(id);
            return new CustomerDTO { Name = Customer.Name, Country = Customer.Country, ContactInfo = Customer.ContactInfo };
        }

        public void SetProjects()
        {
            
        }
    }
}
