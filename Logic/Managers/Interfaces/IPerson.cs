using System.Collections.Generic;
using Logic.DTO;

namespace Logic.Managers.Interfaces
{
    public interface IPerson
    {
        PersonDTO GetInfoOnePersonbyID(PersonDTO DTO);
        IEnumerable<PersonDTO> GetAllPerson();
        IEnumerable<PersonDTO> GetAllPersonByTeam(string team);
        void AddPerson(PersonDTO DTO);
        void DeletePerson(PersonDTO DTO);
        PersonDTO GetAllTaskOnePerson(PersonDTO DTO);
        PersonDTO GetLoginByID(PersonDTO DTO);
        void Edit(PersonDTO DTO);

    }
}
