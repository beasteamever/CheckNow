using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers.IRepository
{
    public interface ICustomerRep<CustomerDTO> where CustomerDTO : class
    {
        CustomerDTO GetInfo(int id);
        CustomerDTO SetProjects(); //такое не придумал что еще передавать

    }
}
