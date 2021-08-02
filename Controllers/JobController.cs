using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepairOrderTrakerAPI.Models;
using RepairOrderTrakerAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class JobController : ControllerBase
   {
      #region - Fields & Properties
      private readonly JobService _service;
      private readonly ILogger<JobController> _log;
      #endregion

      #region - Constructors
      public JobController(JobService service, ILogger<JobController> logger)
      {
         _service = service;
         _log = logger;
      }
      #endregion

      #region - Methods
      [HttpGet]
      public ActionResult<List<JobModel>> Get() => _service.Get();

      [HttpGet("{id:length(24)}")]
      public ActionResult<JobModel> Get(string id)
      {
         _log.LogInformation("Get(string id)", id);
         _log.LogDebug("In Get(string id)");
         var result = _service.Get(id);
         return result is null ? NotFound() : result;
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
