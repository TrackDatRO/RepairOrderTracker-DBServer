using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using RepairOrderTrakerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepairOrderTrakerAPI.Controllers
{
#if DEBUG && testEP
   [Route("api/debug/[controller]")]
   [ApiController]
   public class TestModelController : ControllerBase
   {
      private UserModel _testModel;
      //private List<PayPeriodModel> _payPeriods;
      //private List<JobModel> _jobs;
      //private List<RepairOrderModel> _ros;
      //private List<TechModel> _techs;

      private readonly ILogger<TestModelController> _log;

      public TestModelController(ILogger<TestModelController> log) => _log = log;

      // GET: api/<TestModelController>
      [HttpGet]
      public ActionResult<UserModel> Get()
      {
         _log.LogDebug("Get()");
         return _testModel;
      }

      // POST api/<TestModelController>
      [HttpPost]
      public ActionResult<UserModel> Post(UserModel newUser)
      {
         _log.LogDebug("Post([FromBody] UserModel newUser)");
         _testModel = newUser;
         _log.LogDebug("Created new test user");
         return newUser;
      }

      // PUT api/<TestModelController>
      [HttpPatch("{id:length(24)}")]
      public ActionResult<UserModel> Patch([FromQuery] ObjectId id, UserModel updatedUser)
      {
         _log.LogDebug("Patch(string id, [FromBody] UserModel updatedUser)");
         if (_testModel.Id == id)
         {
            _log.LogDebug("Updated test user");
            _testModel = updatedUser;
            return _testModel;
         }
         _log.LogDebug("ID doesnt match. Did NOT update user.");
         return _testModel;
      }

      // DELETE api/<TestModelController>
      [HttpDelete("{id:length(24)}")]
      public ActionResult<bool> Delete([FromQuery] ObjectId id)
      {
         _log.LogDebug("Delete(string id)");
         if (_testModel.Id == id)
         {
            _testModel = null;
            _log.LogDebug("ID match. Deleted test user.");
            return true;
         }
         _log.LogDebug("ID did NOT match. Did NOT delete test user.");
         return false;
      }
   }
#endif
}
