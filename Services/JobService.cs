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
      public readonly IMongoCollection<JobModel> _service;
      #endregion

      #region - Constructors
      public JobService(IMongoDatabaseSettings settings)
      {
         var client = new MongoClient(settings.ConnectionString);
         var db = client.GetDatabase(settings.DatabaseName);

         _service = db.GetCollection<JobModel>(settings.JobCollection.CollectionName);
      }
      #endregion

      #region - Methods
      public List<JobModel> Get() => _service.Find(job => true).ToList();

      public JobModel Get(string id) => _service.Find(job => job.Id == id).FirstOrDefault();

      public JobModel Create(JobModel newJob)
      {
         _service.InsertOne(newJob);
         return newJob;
      }

      public JobModel Update(string id, JobModel updatedJob)
      {
         _service.ReplaceOne(job => job.Id == id, updatedJob);
         return updatedJob;
      }

      public bool Remove(string id)
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
