using AdminService.DTOs;
using AdminService.DTOs.Responses;
using AdminService.Services.AdminAccountService;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminAccountService adminAccountService;
        public AdminController(IAdminAccountService adminAccountService)
        {
            this.adminAccountService = adminAccountService;
        }

        [HttpPost("register")]
        public BaseResponse AddAdmin(AdminDTO request)
        {
            return adminAccountService.PutAdmin(request);
        }

        [HttpPost("login")]
        public BaseResponse LoginAdmin(AdminDTO request)
        {
            return adminAccountService.LoginAdmin(request); 
        }

        [HttpPost("get-all")]
        public BaseResponse AdminList()
        {
            return adminAccountService.GetAdmins();
        }
    }
}
