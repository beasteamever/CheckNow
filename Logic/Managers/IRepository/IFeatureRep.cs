using System.Collections.Generic;

namespace Logic.Managers.IRepository
{
    public interface IFeatureRep<FeatureDTO> where FeatureDTO : class
    {
        void Add(FeatureDTO DTO);
        void Edit(FeatureDTO DTO);
        IEnumerable<FeatureDTO> GetTasks();
    }
}
