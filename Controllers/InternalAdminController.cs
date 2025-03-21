using AdminService.DTOs;
using AdminService.DTOs.Responses;
using AdminService.Services.AdminAccountService;
using AdminService.Services.InternalAdminAccountService;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternalAdminController : ControllerBase
    {
        private readonly IInternalAdminAccountService internalAdminAccountService;

        public InternalAdminController(IInternalAdminAccountService internalAdminAccountService)
        {
            this.internalAdminAccountService = internalAdminAccountService;
        }

        [HttpPost("{id}")]
        public IActionResult GetAdminById(int id)
        {
            AdminDTO result = internalAdminAccountService.GetAdminById(id);

            if (result == null)
            {
                return NotFound(new { message = "Admin not found" });
            }

            return Ok(result); 
        }
    }
}
