using AdminService.DTOs.Responses;
using AdminService.DTOs;

namespace AdminService.Services.AdminAccountService
{
    public interface IAdminAccountService
    {
        BaseResponse GetAdmins();
        BaseResponse PutAdmin(AdminDTO request);
        BaseResponse LoginAdmin(AdminDTO request);
    }
}
