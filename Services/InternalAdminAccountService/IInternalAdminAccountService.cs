using AdminService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AdminService.Services.InternalAdminAccountService
{
    public interface IInternalAdminAccountService
    {
        public AdminDTO GetAdminById(int id);
    }
}
