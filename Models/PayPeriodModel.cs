using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Models
{
   public class PayPeriodModel : BaseModel
   {
      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }

      public List<ObjectId> RepairOrderIds { get; set; }
      public List<RepairOrderModel> RepairOrders { get; set; }
   }
}
