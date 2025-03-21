using AdminService.Utilities.ValidationAttributes;

namespace AdminService.DTOs
{
    public class AdminDTO
    {
        [AdminValidation]
        public required int NIC { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
    }
}
