using Logic.DTO;

namespace Logic.Managers.Interfaces
{
    public interface ICustomer
    {
        CustomerDTO GetInfo(int id);
        CustomerDTO SetProjects(); //такое не придумал что еще передавать

    }
}
