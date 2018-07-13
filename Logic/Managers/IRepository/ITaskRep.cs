using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers.IRepository
{
    public interface ITaskRep<TaskDTO> where TaskDTO : class
    {
        void Add(TaskDTO DTO);
        TaskDTO Edit(TaskDTO DTO);
    }
}
