using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using RepairOrderTrakerAPI.Models;
using RepairOrderTrakerAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepairOrderTrakerAPI.Controllers
{
   [Route("api/data/[controller]")]
   [ApiController]
   public class PayPeriodController : ControllerBase
   {
      private readonly PayPeriodService _service;
      private readonly ILogger<PayPeriodController> _log;

      public PayPeriodController(PayPeriodService service, ILogger<PayPeriodController> logger)
      {
         _service = service;
         _log = logger;
      }

      // GET: api/<PayPeriodController>
      [HttpGet]
      public ActionResult<List<PayPeriodModel>> Get() => _service.Get();

      // GET api/<PayPeriodController>
      [HttpGet("{id:length(24)}")]
      public ActionResult<PayPeriodModel> Get([FromQuery] ObjectId id)
      {
         _log.LogInformation("Get(string id)", id);
         _log.LogDebug("In Get(string id)");
         var result = _service.Get(id);
         return result is null ? NotFound() : result;
      }

      // POST api/<PayPeriodController>
      [HttpPost]
      public ActionResult<PayPeriodModel> Post(PayPeriodModel newPayPeriod)
      {
         var createdPayPeriod = _service.Create(newPayPeriod);
         return CreatedAtRoute("GetPayPeriod", new { id = createdPayPeriod.Id.ToString() }, createdPayPeriod);
      }

      // Patch api/<PayPeriodController>
      [HttpPatch("{id:length(24)}")]
      public ActionResult<PayPeriodModel> Patch([FromQuery] ObjectId id, PayPeriodModel updatedPayPeriod)
      {
         var result = _service.Update(id, updatedPayPeriod);
         return result is null ? NotFound(id) : result;
      }

      // DELETE api/<PayPeriodController>
      [HttpDelete("{id:length(24)}")]
      public ActionResult<bool> Delete([FromQuery] ObjectId id) => _service.Remove(id);
   }
}
