using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Multitenant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _service;

        public BranchesController(IBranchService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var branchDetails = await _service.GetAllAsync();
            return Ok(branchDetails);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var branchDetails = await _service.GetByIdAsync(id);
            return Ok(branchDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBranchRequest request)
        {
            return Ok(await _service.CreateAsync(request.BranchName, request.Location));
        }
    }
    public class CreateBranchRequest
    {
        public string BranchName { get; set; }
        public string Location { get; set; }
    }
}