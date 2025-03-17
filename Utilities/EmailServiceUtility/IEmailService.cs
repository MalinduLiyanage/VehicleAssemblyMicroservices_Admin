using AdminService.DTOs.Responses;
using MimeKit;

namespace AdminService.Utilities.EmailServiceUtility
{
    public interface IEmailService
    {
        public Task<BaseResponse> SendEmail(MimeMessage msg);
    }
}
