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
   public class PayPeriodService
   {
      #region - Fields & Properties
      private readonly IMongoCollection<PayPeriodModel> _service;

      private readonly RepairOrderService _repairOrders;
      #endregion

      #region - Constructors
      public PayPeriodService(IMongoDatabaseSettings settings, RepairOrderService repairOrders)
      {
         var client = new MongoClient(settings.ConnectionString);
         var db = client.GetDatabase(settings.DatabaseName);

         _service = db.GetCollection<PayPeriodModel>(settings.GetCollectionString<PayPeriodModel>());
         _repairOrders = repairOrders;
      }
      #endregion

      #region - Methods
      public List<PayPeriodModel> Get()
      {
         var payPeriods = _service.Find(pp => true).ToList();
         foreach (var payPeriod in payPeriods)
         {
            payPeriod.RepairOrders = _repairOrders.Get(payPeriod.RepairOrderIds);
         }
         return payPeriods;
      }

      public List<PayPeriodModel> Get(IEnumerable<ObjectId> ids)
      {
         var payPeriods = _service.Find(p => ids.Contains(p.Id)).ToList();
         foreach (var pp in payPeriods)
         {
            pp.RepairOrders = _repairOrders.Get(pp.RepairOrderIds);
         }
         return payPeriods;
      }
      public PayPeriodModel Get(ObjectId id)
      {
         var pp = _service.Find(pp => pp.Id == id).FirstOrDefault();
         if (pp is not null)
         {
            pp.RepairOrders = _repairOrders.Get(pp.RepairOrderIds);
         }
         return pp;
      }

      public PayPeriodModel Create(PayPeriodModel payPeriod)
      {
         _service.InsertOne(payPeriod);
         return payPeriod;
      }

      public PayPeriodModel Update(ObjectId id, PayPeriodModel updatedePayPeriod)
      {
         _service.ReplaceOne(usr => usr.Id == id, updatedePayPeriod);
         return updatedePayPeriod;
      }

      public bool Remove(ObjectId id)
      {
         var results = _service.DeleteOne(pp => pp.Id == id);
         return results.DeletedCount > 0;
      }

      public bool Remove(PayPeriodModel payPeriod) => Remove(payPeriod.Id);
      #endregion
   }
}
