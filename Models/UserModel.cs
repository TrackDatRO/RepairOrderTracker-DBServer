using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Models
{
   public class UserModel : BaseModel
   {
      public string UserName { get; set; }
      public string Password { get; set; }

      [BsonRepresentation(BsonType.Array)]
      public List<string> PayPeriods { get; set; }
   }
}
