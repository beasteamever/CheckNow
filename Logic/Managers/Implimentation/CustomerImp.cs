using System;
using System.Collections.Generic;
using Logic.DTO;
using Logic.Managers.Interfaces;
using Storage;

namespace Logic.Managers.Implimentation
{
    class CustomerImp : ICustomer
    {
        private readonly Context db;

        public CustomerDTO GetInfo(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerDTO SetProjects()
        {
            throw new NotImplementedException();
        }
    }
}
