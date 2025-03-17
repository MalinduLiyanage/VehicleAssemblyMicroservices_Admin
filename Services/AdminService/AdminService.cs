using AdminApi;
using AdminService;
using AdminService.DTOs;
using AdminService.DTOs.Requests.EmailRequests;
using AdminService.DTOs.Responses;
using AdminService.Models;
using AdminService.Utilities.EmailServiceUtility;
using AdminService.Utilities.EmailServiceUtility.AdminAccountCreation;
using AdminService.Utilities.PasswordHashUtility;

namespace AdminService.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext context;
        private readonly IEmailService emailService;

        public AdminService(ApplicationDbContext context, IEmailService emailService)
        {
            this.context = context;
            this.emailService = emailService;
        }

        public BaseResponse GetAdmins()
        {
            BaseResponse response;
            try
            {
                List<AdminDTO> admins = new List<AdminDTO>();

                using (context)
                {
                    context.admins.ToList().ForEach(admin => admins.Add(new AdminDTO
                    {
                        NIC = admin.NIC,
                        Firstname = admin.Firstname,
                        Lastname = admin.Lastname,
                        Email = admin.Email,
                    }));
                }
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { admins }
                };
                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error" + ex.Message }
                };
                return response;
            }
        }

        public BaseResponse LoginAdmin(AdminDTO request)
        {
            throw new NotImplementedException();
        }

        public BaseResponse PutAdmin(AdminDTO request)
        {
            BaseResponse response;
            PasswordHashUtilityService password = new PasswordHashUtilityService();
            try
            {
                AdminModel newAdmin = new AdminModel();
                newAdmin.NIC = request.NIC;
                newAdmin.Firstname = request.Firstname;
                newAdmin.Lastname = request.Lastname;
                newAdmin.Email = request.Email;
                newAdmin.Password = password.PasswordHash;

                AdminAccountEmailRequestDTO AccCreationRequest = new AdminAccountEmailRequestDTO
                {
                    NIC = request.NIC,
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    Email = request.Email,
                    Password = password.generatedPassword
                };

                AdminAccountCreationEmailServiceUtility message = new AdminAccountCreationEmailServiceUtility(AccCreationRequest);

                using (context)
                {
                    context.Add(newAdmin);
                    context.SaveChanges();
                }
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new
                    {
                        message = "Successfully created a Admin Record",
                        email_status = emailService.SendEmail(message)
                    }

                };
                return response;
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error" + ex.Message }
                };
                return response;
            }
        }
    }
}
