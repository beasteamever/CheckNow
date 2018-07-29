using System;
using System.Collections.Generic;
using Logic.DTO;
using Logic.Managers.Interfaces;
using Storage.Models;
using System.Linq;

namespace Logic.Managers.Implimentation
{
    public class FeatureImp : IFeature
    {
        private readonly Context db;
        Feature Feature;

        public void Add(FeatureDTO DTO)
        {
            Feature = new Feature
            {
                FeatureId = DTO.FeatureId,
                Name = DTO.Name,
                Info = DTO.Info,
                ProjectId = DTO.ProjectId
            };
            db.SaveChanges();
        }

        public void Edit(FeatureDTO DTO)
        {
            Feature = db.Feature.Find(DTO.FeatureId);
            Feature.Name = DTO.Name;
            Feature.Info = DTO.Info;
            Feature.ProjectId = DTO.ProjectId;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var feature = db.Feature.Where(f=> f.FeatureId == id).FirstOrDefault();
            db.Feature.Remove(feature);
            db.SaveChanges();
        }

        public FeatureDTO GetTasks(FeatureDTO DTO)
        {
            FeatureDTO dTO = new FeatureDTO { };
            var person = db.Person.Find(DTO);
            foreach (var I in person.Tasks)
            { dTO.TaskId.Add(new TaskDTO { Name = I.Name }); }
            return dTO;
        }
    }
}
