using RepairOrderTrakerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Settings
{
   public class MongoDatabaseSettings : IMongoDatabaseSettings
   {
      public string ConnectionString { get; set; }
      public string DatabaseName { get; set; }

      public Dictionary<string, string> CollectionNames { get; set; }

      public string GetCollectionString<T>() where T : BaseModel, new()
      {
         string name = new T().GetType().Name;
         return CollectionNames[name];
      }
   }

   public interface IMongoDatabaseSettings
   {
      string ConnectionString { get; set; }
      string DatabaseName { get; set; }
      Dictionary<string, string> CollectionNames { get; set; }
      string GetCollectionString<T>() where T : BaseModel, new();
   }
}
