using AdminApi;
using AdminService.DTOs;
using AdminService.DTOs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AdminService.Services.InternalAdminAccountService
{
    public class InternalAdminAccountService : IInternalAdminAccountService
    {
        private readonly ApplicationDbContext context;

        public InternalAdminAccountService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public AdminDTO GetAdminById(int id)
        {
            try
            {
                var admin = context.admins
                    .Where(a => a.NIC == id)
                    .Select(a => new AdminDTO
                    {
                        NIC = a.NIC,
                        Firstname = a.Firstname,
                        Lastname = a.Lastname,
                        Email = a.Email
                    })
                    .FirstOrDefault();

                return admin;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
