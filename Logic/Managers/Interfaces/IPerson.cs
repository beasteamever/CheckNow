using System.Collections.Generic;
using System.Text;
using Logic.DTO;

namespace Logic.Managers.Interfaces
{
    public interface IPerson
    {
        PersonDTO GetInfoOnePersonbyID(int id);
        IEnumerable<PersonDTO> GetAllPerson();
        IEnumerable<PersonDTO> GetAllPersonByTeam(StringBuilder team);
        void AddPerson(PersonDTO DTO);
        void DeletePerson(int id);
        PersonDTO GetAllTaskOnePerson(int id);
        PersonDTO GetLoginByID(int id);
        void Edit(PersonDTO DTO);
        StringBuilder GetPicture(int id);
        void SetPicture(int id, StringBuilder pic);

    }
}
