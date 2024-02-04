using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace ECommerce.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UserController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _service.UserService.GetAllUsers(trackChanges: false);
            return Ok(users);
        }
    }
}
