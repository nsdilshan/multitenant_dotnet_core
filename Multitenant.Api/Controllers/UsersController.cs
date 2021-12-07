using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Multitenant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var userDetails = await _service.GetAllAsync();
            return Ok(userDetails);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var userDetails = await _service.GetByIdAsync(id);
            return Ok(userDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserRequest request)
        {
            return Ok(await _service.CreateAsync(request.UserName, request.Email));
        }
    }
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}