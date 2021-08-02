using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepairOrderTrakerAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Controllers
{
   public class ModelController<T> : ControllerBase
   {
      #region - Fields & Properties
      private readonly JobService _service;
      private readonly ILogger<T> _log;
      #endregion

      #region - Constructors
      public ModelController() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
