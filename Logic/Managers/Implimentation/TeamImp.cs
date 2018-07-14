using System;
using System.Collections.Generic;
using Logic.DTO;
using Logic.Managers.Interfaces;
using Storage;

namespace Logic.Managers.Implimentation
{
    public class TeamImp : ITeam
    {
        private readonly Context db;

        public void AddPerson(TeamDTO DTO)
        {
            throw new NotImplementedException();
        }

        public void Edit(TeamDTO DTO)
        {
            throw new NotImplementedException();
        }

        public TeamDTO GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamDTO> GetPersons()
        {
            throw new NotImplementedException();
        }

        public void GetProject(string Project)
        {
            throw new NotImplementedException();
        }

        public void SetProject(string project)
        {
            throw new NotImplementedException();
        }
    }
}
