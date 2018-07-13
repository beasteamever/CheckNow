using System.Collections.Generic;

namespace Logic.Managers.IRepository
{
    public interface ITeamRep<TeamDTO> where TeamDTO : class
    {
        TeamDTO GetByID(int id);
        void SetProject(string project);
        void AddPerson(TeamDTO DTO);       
        IEnumerable<TeamDTO> GetPersons();
        void GetProject(string Project);
        void Edit(TeamDTO DTO);

    }
}
