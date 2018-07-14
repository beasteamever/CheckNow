using Logic.DTO;

namespace Logic.Managers.Interfaces
{
    public interface ICustomer
    {
        CustomerDTO GetInfo(int id);
        void SetProjects(); //такое не придумал что еще передавать

    }
}
