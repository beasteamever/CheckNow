using System;
using System.Collections.Generic;
using Logic.DTO;
using Logic.Managers.Interfaces;
using Storage.Models;
using System.Linq;

namespace Logic.Managers.Implimentation
{
    public class PersonImp : IPerson
    {
        private readonly Context db;
        Person Person;

        public void AddPerson(PersonDTO DTO)
        {
            Person = new Person
            {
                Name = DTO.Name,
                Mail = DTO.Mail,
                Phone = DTO.Phone,

            };
            db.Person.Add(Person);
            db.SaveChanges();

        }

        public void DeletePerson(PersonDTO DTO)
        {

            var person = db.Person.Where(p => p.Id == DTO.Id).FirstOrDefault();
            db.Person.Remove(person);
            db.SaveChanges();
        }

        public void Edit(PersonDTO DTO)
        {
            Person = db.Person.Find(DTO.Id);
            Person.Name = DTO.Name;
            Person.Mail = DTO.Mail;
            Person.Phone = DTO.Phone;            
            db.SaveChanges();

        }

        public IEnumerable<PersonDTO> GetAllPerson()
        {
            var persons = db.Person.Select(p => new PersonDTO
            {
                Name = p.Name
            });
            return persons;
        }

        public IEnumerable<PersonDTO> GetAllPersonByTeam(string team)
        {
            var person = db.Person.Where(p => p.TeamName == team).
                 Select(p => new PersonDTO
                 {
                     Name = p.Name,
                     Mail = p.Mail,
                     Phone = p.Phone,
                     Login = p.Login
                 });
            return person;

        }

        public PersonDTO GetAllTaskOnePerson(PersonDTO DTO)
        {
            PersonDTO dTO = new PersonDTO { };
            var person = db.Person.Find(DTO.Id);
            foreach (var I in person.Tasks)
            { dTO.Tasks.Add(new TaskDTO { Name = I.Name }); }
            return dTO;

        }

        public PersonDTO GetInfoOnePersonbyID(PersonDTO DTO)
        {
            var person = db.Person.Find(DTO.Id);
            return new PersonDTO { Name = person.Name, Mail = person.Mail, Phone = person.Phone, TeamName= person.TeamName };


        }

        public PersonDTO GetLoginByID(PersonDTO DTO)
        {
            var person = db.Person.Find(DTO.Id);
            return new PersonDTO { Login = person.Login };

        }
    }
}
