using System;
using System.Collections.Generic;
using Logic.DTO;
using Logic.Managers.Interfaces;
using Storage.Models;
using System.Linq;

namespace Logic.Managers.Implimentation
{
    public class ProjectImp : IProject
    {
        private readonly Context db;

        Project Project;
        public void CreateProject(ProjectDTO DTO)
        {
            Project = new Project
            {
                ProjectId = DTO.ProjectId,
                Name = DTO.Name,
                State = DTO.State,
                Priority = DTO.Priority,
                DateStart = DTO.DateStart,
                DateEndings = DTO.DateEndings,
                Deadline = DTO.Deadline,
                Info = DTO.Info,
                projectManager = DTO.projectManager,
                CustomerName = DTO.CustomerName,
                TeamName = DTO.TeamName
            };

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = db.Project.Find(id);
            db.Project.Remove(project);

            db.SaveChanges();
        }

        public void EditProject(ProjectDTO DTO)
        {
            Project = db.Project.Find(DTO.ProjectId);
            Project.Name = DTO.Name;
            Project.State = DTO.State;
            Project.Priority = DTO.Priority;
            Project.DateStart = DTO.DateStart;
            Project.DateEndings = DTO.DateEndings;
            Project.Deadline = DTO.Deadline;
            Project.Info = DTO.Info;
            Project.projectManager = DTO.projectManager;
            Project.CustomerName = DTO.CustomerName;
            Project.TeamName = DTO.TeamName;

            db.SaveChanges();
        }

        public ProjectDTO GetInfoByProjectID(int id)
        {
            Project = db.Project.Find(id);
            return new ProjectDTO
            {
                ProjectId = Project.ProjectId,
                Name = Project.Name,
                State = Project.State,
                Priority = Project.Priority,
                DateStart = Project.DateStart,
                DateEndings = Project.DateEndings,
                Deadline = Project.Deadline,
                projectManager = Project.projectManager,
                CustomerName = Project.CustomerName,
                TeamName = Project.TeamName
            };
        }
    }
}
