using System.ComponentModel.DataAnnotations;
using AdminService.DTOs;
using AdminService.Services.ValidationService;

namespace AdminService.Utilities.ValidationAttributes
{
    public class AdminValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            AdminDTO request = (AdminDTO)validationContext.ObjectInstance;

            if (request.NIC <= 0 || request.Firstname == null || request.Lastname == null || request.Email == null)
            {
                return new ValidationResult("All fields are required.");
            }

            ICreateAdminValidationService? validationService = validationContext.GetService(typeof(ICreateAdminValidationService)) as ICreateAdminValidationService;

            if (validationService == null)
            {
                return new ValidationResult("Validation service is unavailable.");
            }

            List<string> validationErrors = validationService.Validate(request);

            if (validationErrors.Any())
            {
                return new ValidationResult(string.Join("; ", validationErrors));
            }

            return ValidationResult.Success;
        }
    }
}
