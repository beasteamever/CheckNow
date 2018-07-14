using System;
using System.Collections.Generic;
using Logic.DTO;
using Logic.Managers.Interfaces;
using Storage;

namespace Logic.Managers.Implimentation
{
    public class TaskImp : ITask
    {
        private readonly Context db;

        public void Add(TaskDTO DTO)
        {
            throw new NotImplementedException();
        }

        public TaskDTO Edit(TaskDTO DTO)
        {
            throw new NotImplementedException();
        }
    }
}
