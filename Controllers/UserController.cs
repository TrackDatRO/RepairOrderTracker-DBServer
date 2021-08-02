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
   public class UserController : ControllerBase
   {
      #region - Fields & Properties
      private readonly UserService _service;
      private readonly ILogger<UserController> _log;
      #endregion

      #region - Constructors
      public UserController(UserService service, ILogger<UserController> logger)
      {
         _service = service;
         _log = logger;
      }
      #endregion

      #region - Methods
      [HttpGet]
      public ActionResult<List<UserModel>> Get() => _service.Get();

      [HttpGet("{id:length(24)}")]
      public ActionResult<UserModel> Get(string id)
      {
         _log.LogInformation("Get(string id)", id);
         _log.LogDebug("In Get(string id)");
         var result = _service.Get(id);
         return result is null ? NotFound() : result;
      }

      [HttpPost]
      public ActionResult<UserModel> Post(UserModel newUser)
      {
         var createdUser = _service.Create(newUser);
         return CreatedAtRoute("GetUser", new { id = createdUser.Id.ToString() }, createdUser);
      }

      [HttpPatch("{id:length(24)}")]
      public ActionResult<UserModel> Patch(string id, UserModel updatedUser)
      {
         var result = _service.Update(id, updatedUser);
         if (result is null)
         {
            return NotFound(id);
         }
         return result;
      }

      [HttpDelete("{id:length(24)}")]
      public ActionResult<bool> Delete(string id) => _service.Remove(id);
      #endregion

      #region - Full Properties

      #endregion
   }
}
