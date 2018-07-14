using Logic.DTO;

namespace Logic.Managers.Interfaces
{
    public interface ITask
    {
        void Add(TaskDTO DTO);
        TaskDTO Edit(TaskDTO DTO);
    }
}
