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
   public class RepairOrderController : ControllerBase
   {
      private readonly RepairOrderService _service;
      private readonly ILogger<RepairOrderController> _log;

      public RepairOrderController(RepairOrderService service, ILogger<RepairOrderController> logger)
      {
         _service = service;
         _log = logger;
      }

      // GET api/<RepairOrderController>
      [HttpGet]
      public ActionResult<List<RepairOrderModel>> Get() => _service.Get();

      // GET api/<RepairOrderController>
      [HttpGet("{id:length(24)}")]
      public ActionResult<RepairOrderModel> Get([FromQuery] ObjectId id)
      {
         _log.LogInformation("Get(string id)", id);
         _log.LogDebug("In Get(string id)");
         var result = _service.Get(id);
         return result is null ? NotFound() : result;
      }

      // POST api/<RepairOrderController>
      [HttpPost]
      public ActionResult<RepairOrderModel> Post(RepairOrderModel newRO)
      {
         var createdRO = _service.Create(newRO);
         return CreatedAtRoute("GetUser", new { id = createdRO.Id.ToString() }, createdRO);
      }

      // PUT api/<RepairOrderController>/5
      [HttpPatch("{id:length(24)}")]
      public ActionResult<RepairOrderModel> Patch([FromQuery] ObjectId id, RepairOrderModel updatedRO)
      {
         var result = _service.Update(id, updatedRO);
         return result is null ? NotFound(id) : result;
      }

      // DELETE api/<RepairOrderController>/5
      [HttpDelete("{id:length(24)}")]
      public ActionResult<bool> Delete(ObjectId id) => _service.Remove(id);
   }
}
