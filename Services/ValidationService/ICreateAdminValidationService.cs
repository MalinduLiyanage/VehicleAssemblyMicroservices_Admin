using AdminService.DTOs;

namespace AdminService.Services.ValidationService
{
    public interface ICreateAdminValidationService
    {
        List<string> Validate(AdminDTO request);
    }
}
