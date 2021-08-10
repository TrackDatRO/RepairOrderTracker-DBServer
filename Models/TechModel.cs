using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Models
{
   public class TechModel : BaseModel
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int TechNumber { get; set; }
      public double TotalTime { get; set; }
   }
}
