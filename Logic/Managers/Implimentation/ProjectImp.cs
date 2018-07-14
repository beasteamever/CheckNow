using System;
using System.Collections.Generic;
using Logic.DTO;
using Logic.Managers.Interfaces;
using Storage;

namespace Logic.Managers.Implimentation
{
    public class ProjectImp : IProject
    {
        private readonly Context db;

        public void CreateProject(ProjectDTO DTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void EditProject(ProjectDTO DTO)
        {
            throw new NotImplementedException();
        }

        public void GetInfoByProjectID(ProjectDTO DTO)
        {
            throw new NotImplementedException();
        }
    }
}
