using System;
using System.Collections.Generic;
using Logic.DTO;
using Logic.Managers.Interfaces;
using Storage.Models;

namespace Logic.Managers.Implimentation
{
    public class TaskImp : ITask
    {
        private readonly Context db;

        Task Task;
        public void Add(TaskDTO DTO)
        {
            Task = new Task
            {
                TaskId = DTO.TaskId,
                Name = DTO.Name,
                State = DTO.State,
                Code = DTO.Code,
                Info = DTO.Info,
                FeatureId = DTO.FeatureId,
                DateTime = DTO.DateTime,
                PersonName = DTO.PersonName
            };
            db.SaveChanges();
        }

        public void Edit(TaskDTO DTO)
        {
            Task = db.Task.Find(DTO.TaskId);
            Task.Name = DTO.Name;
            Task.State = DTO.State;
            Task.Code = DTO.Code;
            Task.Info = DTO.Info;
            Task.FeatureId = DTO.FeatureId;
            Task.DateTime = DTO.DateTime;
            Task.PersonName = DTO.PersonName;

            db.SaveChanges();
        }
    }
}
