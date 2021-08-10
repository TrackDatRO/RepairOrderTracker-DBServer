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
   public class TechController : ControllerBase
   {
      private readonly TechService _service;
      private readonly ILogger<TechController> _log;

      public TechController(TechService service, ILogger<TechController> log)
      {
         _service = service;
         _log = log;
      }

      // GET: api/<TechController>
      [HttpGet]
      public ActionResult<List<TechModel>> Get() => _service.Get();

      // GET api/<TechController>
      [HttpGet("{id:length(24)}")]
      public ActionResult<TechModel> Get([FromQuery] ObjectId id)
      {
         _log.LogInformation("Get(string id)", id);
         _log.LogDebug("In Get(string id)");
         var result = _service.Get(id);
         return result is null ? NotFound() : result;
      }

      // POST api/<TechController>
      [HttpPost]
      public ActionResult<TechModel> Post(TechModel newTech)
      {
         var createdTech = _service.Create(newTech);
         return CreatedAtRoute("GetTech", new { id = createdTech.Id.ToString() }, createdTech);
      }

      // PUT api/<TechController>/5
      [HttpPatch("{id:length(24)}")]
      public ActionResult<TechModel> Patch([FromQuery] ObjectId id, TechModel updatedTech)
      {
         var result = _service.Update(id, updatedTech);
         return result is null ? NotFound(id) : result;
      }

      // DELETE api/<TechController>/5
      [HttpDelete("{id:length(24)}")]
      public ActionResult<bool> Delete([FromQuery] ObjectId id) => _service.Remove(id);
   }
}
