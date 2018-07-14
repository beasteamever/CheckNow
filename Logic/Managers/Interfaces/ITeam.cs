using System.Collections.Generic;
using Logic.DTO;

namespace Logic.Managers.Interfaces
{
    public interface ITeam
    {
        TeamDTO GetByID(int id);
        void SetProject(string project);
        void AddPerson(TeamDTO DTO);       
        IEnumerable<TeamDTO> GetPersons();
        void GetProject(string Project);
        void Edit(TeamDTO DTO);

    }
}
