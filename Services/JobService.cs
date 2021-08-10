using MongoDB.Bson;
using MongoDB.Driver;
using RepairOrderTrakerAPI.Models;
using RepairOrderTrakerAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Services
{
   public class JobService
   {
      #region - Fields & Properties
      private readonly IMongoCollection<JobModel> _service;
      private readonly TechService _techs;
      #endregion

      #region - Constructors
      public JobService(IMongoDatabaseSettings settings, TechService techs)
      {
         var client = new MongoClient(settings.ConnectionString);
         var db = client.GetDatabase(settings.DatabaseName);

         _service = db.GetCollection<JobModel>(settings.GetCollectionString<JobModel>());
         _techs = techs;
      }
      #endregion

      #region - Methods
      public List<JobModel> Get()
      {
         var work = _service.Find(job => true).ToList();
         foreach (var w in work)
         {
            w.AssignedTech = _techs.Get(w.AssignedTechId);
         }
         return work;
      }

      public JobModel Get(ObjectId id)
      {
         var job = _service.Find(job => job.Id == id).FirstOrDefault();
         if (job is not null)
         {
            job.AssignedTech = _techs.Get(job.AssignedTechId);
         }
         return job;
      }

      public List<JobModel> Get(IEnumerable<ObjectId> ids)
      {
         var work = _service.Find(job => ids.Contains(job.Id)).ToList();
         foreach (var w in work)
         {
            w.AssignedTech = _techs.Get(w.AssignedTechId);
         }
         return work;
      }
      public JobModel Create(JobModel newJob)
      {
         _service.InsertOne(newJob);
         return newJob;
      }

      public JobModel Update(ObjectId id, JobModel updatedJob)
      {
         _service.ReplaceOne(job => job.Id == id, updatedJob);
         return updatedJob;
      }

      public bool Remove(ObjectId id)
      {
         var result = _service.DeleteOne(job => job.Id == id);
         return result.DeletedCount > 0;
      }

      public bool Remove(JobModel job)
      {
         var result = _service.DeleteOne(j => job.Id == j.Id);
         return result.DeletedCount > 0;
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
