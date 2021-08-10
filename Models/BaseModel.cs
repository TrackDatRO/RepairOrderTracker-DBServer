using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Models
{
   public class BaseModel
   {
      [BsonId]
      public ObjectId Id { get; set; }

      public BaseModel() => Id = ObjectId.GenerateNewId();
   }
}
