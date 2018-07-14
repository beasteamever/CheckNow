using System.Collections.Generic;
using Logic.DTO;

namespace Logic.Managers.Interfaces
{
    public interface IFeature
    {
        void Add(FeatureDTO DTO);
        void Edit(FeatureDTO DTO);
        IEnumerable<FeatureDTO> GetTasks();
    }
}
