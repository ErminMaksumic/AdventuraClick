using System.ComponentModel.DataAnnotations;


namespace AdventuraClick.Model.Requests
{
    public class UserUpdateRequest
    {
        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public string LastName { get; set; }

        [EmailAddress(), MaxLength(25)]
        public string? Email { get; set; }
        [MaxLength(20)]
        public string? Password { get; set; }
        [MaxLength(20)]
        public string? PasswordConfirmation { get; set; }
        public byte[]? Image { get; set; }
    }
}
