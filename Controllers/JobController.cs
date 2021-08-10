using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using RepairOrderTrakerAPI.Models;
using RepairOrderTrakerAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairOrderTrakerAPI.Controllers
{
   [ApiController]
   [Route("api/data/[controller]")]
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
      public ActionResult<JobModel> Get([FromQuery] ObjectId id)
      {
         _log.LogInformation("Get(string id)", id);
         _log.LogDebug("In Get(string id)");
         var result = _service.Get(id);
         return result is null ? NotFound() : result;
      }

      [HttpPost]
      public ActionResult<JobModel> Post(JobModel newJob)
      {
         var createdJob = _service.Create(newJob);
         return CreatedAtRoute("GetJob", new { id = createdJob.Id.ToString() }, createdJob);
      }

      [HttpPatch("{id:length(24)}")]
      public ActionResult<JobModel> Patch([FromQuery] ObjectId id, JobModel updatedJob)
      {
         var result = _service.Update(id, updatedJob);
         return result is null ? NotFound(id) : result;
      }

      [HttpDelete("{id:length(24)}")]
      public ActionResult<bool> Delete([FromQuery] ObjectId id) => _service.Remove(id);
      #endregion

      #region - Full Properties

      #endregion
   }
}
