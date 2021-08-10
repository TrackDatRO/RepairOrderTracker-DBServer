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
   public class RepairOrderService
   {
      #region - Fields & Properties
      private readonly IMongoCollection<RepairOrderModel> _service;

      private readonly JobService _jobs;
      #endregion

      #region - Constructors
      public RepairOrderService(IMongoDatabaseSettings settings, JobService jobs)
      {
         var client = new MongoClient(settings.ConnectionString);
         var db = client.GetDatabase(settings.DatabaseName);

         _service = db.GetCollection<RepairOrderModel>(settings.GetCollectionString<RepairOrderModel>());
         _jobs = jobs;
      }
      #endregion

      #region - Methods
      public List<RepairOrderModel> Get()
      {
         var ros = _service.Find(ro => true).ToList();
         foreach (var ro in ros)
         {
            ro.Work = _jobs.Get(ro.WorkIds);
         }
         return ros;
      }

      public RepairOrderModel Get(ObjectId id)
      {
         var ro = _service.Find(ro => ro.Id == id).FirstOrDefault();
         if (ro is not null)
         {
            ro.Work = _jobs.Get(ro.WorkIds);
         }
         return ro;
      }

      public List<RepairOrderModel> Get(IEnumerable<ObjectId> ids)
      {
         var ros = _service.Find(ro => ids.Contains(ro.Id)).ToList();
         foreach (var ro in ros)
         {
            ro.Work = _jobs.Get(ro.WorkIds);
         }
         return ros;
      }

      public RepairOrderModel Create(RepairOrderModel repairOrder)
      {
         _service.InsertOne(repairOrder);
         return repairOrder;
      }

      public RepairOrderModel Update(ObjectId id, RepairOrderModel updatedeRO)
      {
         _service.ReplaceOne(ro => ro.Id == id, updatedeRO);
         return updatedeRO;
      }

      public bool Remove(ObjectId id)
      {
         var results = _service.DeleteOne(ro => ro.Id == id);
         return results.DeletedCount > 0;
      }

      public bool Remove(RepairOrderModel repairOrder) => Remove(repairOrder.Id);
      #endregion
   }
}
