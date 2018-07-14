using Logic.DTO;

namespace Logic.Managers.Interfaces
{
    public interface IProject
    {
        void GetInfoByProjectID(ProjectDTO DTO); //!info, features
        void Delete(int id);
        void CreateProject(ProjectDTO DTO);
        void EditProject(ProjectDTO DTO);

    }
}
