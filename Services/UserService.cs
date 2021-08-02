using MongoDB.Driver;
using RepairOrderTrakerAPI.Models;
using RepairOrderTrakerAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Services
{
   public class UserService
   {
      #region - Fields & Properties
      private readonly IMongoCollection<UserModel> _service;
      #endregion

      #region - Constructors
      public UserService(IMongoDatabaseSettings settings)
      {
         var client = new MongoClient(settings.ConnectionString);
         var db = client.GetDatabase(settings.DatabaseName);

         _service = db.GetCollection<UserModel>(settings.UserCollection.CollectionName);
      }
      #endregion

      #region - Methods
      public List<UserModel> Get() => _service.Find(usr => true).ToList();

      public UserModel Get(string id) => _service.Find(usr => usr.Id == id).FirstOrDefault();

      public UserModel Create(UserModel user)
      {
         _service.InsertOne(user);
         return user;
      }

      public UserModel Update(string id, UserModel updatedeUser)
      {
         _service.ReplaceOne(usr => usr.Id == id, updatedeUser);
         return updatedeUser;
      }

      public bool Remove(string id)
      {
         var results = _service.DeleteOne(usr => usr.Id == id);
         return results.DeletedCount > 0;
      }

      public bool Remove(UserModel user)
      {
         return Remove(user.Id);
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
