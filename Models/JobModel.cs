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
      public double Time { get; set; }

      [BsonId]
      [BsonRepresentation(BsonType.ObjectId)]
      public string AssignedTech { get; set; }
   }
}
