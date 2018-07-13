namespace Logic.Managers.IRepository
{
    public interface IProjectRep<ProjectDTO> where ProjectDTO : class
    {
        void GetInfoByProjectID(ProjectDTO DTO); //!info, features
        void Delete(int id);
        void CreateProject(ProjectDTO DTO);
        void EditProject(ProjectDTO DTO);

    }
}
