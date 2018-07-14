using System;
using System.Collections.Generic;
using Logic.DTO;
using Logic.Managers.Interfaces;
using Storage.Models;

namespace Logic.Managers.Implimentation
{
    public class TeamImp : ITeam
    {
        private readonly Context db;
        Team Team;

        public void AddPerson(TeamDTO DTO)
        {
            throw new NotImplementedException();
        }

        public void Edit(TeamDTO DTO)
        {
            Team = db.Team.Find(DTO.Id);
            Team.Name = DTO.Name;
            foreach(var I in Team.Projects)
            { DTO.Projects.Add(new ProjectDTO { Name = I.Name }); }
            foreach (var I in Team.Persons)
            { DTO.Persons.Add(new PersonDTO { Name = I.Name }); }
            db.SaveChanges();
        }

        public TeamDTO GetByID(int id)
        {
            Team = db.Team.Find(id);
            return new TeamDTO { Id = Team.Id , Name = Team.Name };


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
