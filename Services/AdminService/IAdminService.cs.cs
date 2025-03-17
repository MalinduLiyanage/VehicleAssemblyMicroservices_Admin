using AdminService.DTOs;
using AdminService.DTOs.Responses;

namespace AdminService.Services.AdminServices
{
    public interface IAdminService
    {
        BaseResponse GetAdmins();
        BaseResponse PutAdmin(AdminDTO request);
        BaseResponse LoginAdmin(AdminDTO request);
    }
}
