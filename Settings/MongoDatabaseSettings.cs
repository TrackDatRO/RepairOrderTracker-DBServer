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
      public CollectionSettings UserCollection { get; set; }
      public CollectionSettings RepairOrderCollection { get; set; }
      public CollectionSettings TechCollection { get; set; }
      public CollectionSettings JobCollection { get; set; }
      public CollectionSettings PayPeriodCollection { get; set; }
   }

   public interface IMongoDatabaseSettings
   {
      string ConnectionString { get; set; }
      string DatabaseName { get; set; }
      CollectionSettings UserCollection { get; set; }
      CollectionSettings RepairOrderCollection { get; set; }
      CollectionSettings TechCollection { get; set; }
      CollectionSettings JobCollection { get; set; }
      CollectionSettings PayPeriodCollection { get; set; }
   }
}
