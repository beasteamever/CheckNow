using System.Collections.Generic;
using Logic.DTO;

namespace Logic.Managers.Interfaces
{
    public interface IFeature
    {
        void Add(FeatureDTO DTO);
        void Edit(FeatureDTO DTO);
        void Delete(FeatureDTO DTO);
        FeatureDTO GetTasks(FeatureDTO DTO);
    }
}
