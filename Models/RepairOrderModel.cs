using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Models
{
   public class RepairOrderModel : BaseModel
   {
      public int RONumber { get; set; }
      public int FlagId { get; set; }
      public bool IsUpsell { get; set; }

      public List<ObjectId> WorkIds { get; set; }
      public List<JobModel> Work { get; set; }
   }
}
