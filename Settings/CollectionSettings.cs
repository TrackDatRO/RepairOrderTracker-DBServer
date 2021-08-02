using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Settings
{
   public class CollectionSettings : ICollectionSettings
   {
      public string CollectionName { get; set; }
   }

   public interface ICollectionSettings
   {
      string CollectionName { get; set; }
   }
}
