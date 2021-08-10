using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Models
{
   public class JobModel : BaseModel
   {
      public string JobName { get; set; }
      public string Description { get; set; }
      public double Time { get; set; }
      public bool IsCompleted { get; set; }

      public ObjectId AssignedTechId { get; set; }
      public TechModel AssignedTech { get; set; }
   }
}
