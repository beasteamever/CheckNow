using Logic.DTO;

namespace Logic.Managers.Interfaces
{
    public interface IProject
    {
        ProjectDTO GetInfoByProjectID(int id); //!info, features
        void Delete(int id);
        void CreateProject(ProjectDTO DTO);
        void EditProject(ProjectDTO DTO);

    }
}
