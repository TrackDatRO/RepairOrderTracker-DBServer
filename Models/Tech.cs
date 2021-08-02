using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Models
{
   public class Tech : BaseModel
   {
      public string Name { get; set; }
      public int TechNumber { get; set; }
      public double TotalTime { get; set; }
   }
}
