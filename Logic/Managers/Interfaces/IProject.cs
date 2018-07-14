using Logic.DTO;

namespace Logic.Managers.Interfaces
{
    public interface IProject
    {
        ProjectDTO GetInfoByProjectID(ProjectDTO DTO); //!info, features
        void Delete(ProjectDTO DTO);
        void CreateProject(ProjectDTO DTO);
        void EditProject(ProjectDTO DTO);

    }
}
