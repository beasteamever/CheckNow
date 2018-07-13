using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Managers.IRepository
{
    public interface IPersonRep<PersonDTO> where PersonDTO : class
    {
        PersonDTO GetInfoOnePersonbyID(int id);
        IEnumerable<PersonDTO> GetAllPerson();
        IEnumerable<PersonDTO> GetAllPersonByTeam(string team);
        void AddPerson(PersonDTO DTO);
        void DeletePerson(int id);
        PersonDTO GetAllTaskOnePerson(int id);
        PersonDTO GetLoginByID(int id);
        PersonDTO Edit(PersonDTO DTO);

    }
}
