using System;
using System.Collections.Generic;
using Logic.DTO;
using Logic.Managers.Interfaces;
using Storage;

namespace Logic.Managers.Implimentation
{
    public class FeatureImp : IFeature
    {
        private readonly Context db;

        public void Add(FeatureDTO DTO)
        {
            throw new NotImplementedException();
        }

        public void Edit(FeatureDTO DTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FeatureDTO> GetTasks()
        {
            throw new NotImplementedException();
        }
    }
}
