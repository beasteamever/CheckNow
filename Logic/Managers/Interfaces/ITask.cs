using Logic.DTO;

namespace Logic.Managers.Interfaces
{
    public interface ITask
    {
        void Add(TaskDTO DTO);
        void Edit(TaskDTO DTO);
    }
}
