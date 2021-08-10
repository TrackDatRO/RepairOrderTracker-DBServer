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
   public class TechService
   {
      #region - Fields & Properties
      private readonly IMongoCollection<TechModel> _service;
      #endregion

      #region - Constructors
      public TechService(IMongoDatabaseSettings settings)
      {
         var client = new MongoClient(settings.ConnectionString);
         var db = client.GetDatabase(settings.DatabaseName);

         _service = db.GetCollection<TechModel>(settings.GetCollectionString<TechModel>());
      }
      #endregion

      #region - Methods
      public List<TechModel> Get() => _service.Find(t => true).ToList();
      public TechModel Get(ObjectId id) => _service.Find(t => t.Id == id).FirstOrDefault();

      public TechModel Create(TechModel tech)
      {
         if (_service.Find(t => t.Id == tech.Id).Any())
         {
            return Update(tech.Id, tech);
         }
         _service.InsertOne(tech);
         return tech;
      }

      public TechModel Update(ObjectId id, TechModel updatedeTech)
      {
         _service.ReplaceOne(t => t.Id == id, updatedeTech);
         return updatedeTech;
      }

      public bool Remove(string id)
      {
         var results = _service.DeleteOne(tech => tech.Id == new ObjectId(id));
         return results.DeletedCount > 0;
      }

      public bool Remove(ObjectId id)
      {
         var results = _service.DeleteOne(tech => tech.Id == id);
         return results.DeletedCount > 0;
      }

      public bool Remove(TechModel tech) => Remove(tech.Id);
      #endregion
   }
}
