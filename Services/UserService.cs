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
   public class UserService
   {
      #region - Fields & Properties
      private readonly IMongoCollection<UserModel> _usersDB;

      private readonly PayPeriodService _payPeriods;
      #endregion

      #region - Constructors
      public UserService(IMongoDatabaseSettings settings, PayPeriodService payPeriods)
      {
         var client = new MongoClient(settings.ConnectionString);
         var db = client.GetDatabase(settings.DatabaseName);

         _usersDB = db.GetCollection<UserModel>(settings.GetCollectionString<UserModel>());
         _payPeriods = payPeriods;
      }
      #endregion

      #region - Methods
#if DEBUG
      /// <summary>
      /// Development ONLY!!
      /// </summary>
      /// <returns>All Users, regardless of credentials.</returns>
      public List<UserModel> Get()
      {
         var users = _usersDB.Find(usr => true).ToList();
         foreach (var user in users)
         {
            user.PayPeriods = _payPeriods.Get(user.PayPeriodIds);
         }
         return users;
      }
#endif

      public UserModel Get(ObjectId id)
      {
         var user = _usersDB.Find(usr => usr.Id == id).FirstOrDefault();
         if (user is not null)
         {
            user.PayPeriods = _payPeriods.Get(user.PayPeriodIds);
         }
         return user;
      }

      //public UserModel Create(string username, string password)
      //{

      //}

      public UserModel Create(UserModel user)
      {

         _usersDB.InsertOne(user);
         return user;
      }

      public UserModel Update(ObjectId id, UserModel updatedeUser)
      {
         _usersDB.ReplaceOne(usr => usr.Id == id, updatedeUser);
         return updatedeUser;
      }

      public bool Remove(ObjectId id)
      {
         var results = _usersDB.DeleteOne(usr => usr.Id == id);
         return results.DeletedCount > 0;
      }

      public bool Remove(UserModel user) => Remove(user.Id);
      #endregion
   }
}
