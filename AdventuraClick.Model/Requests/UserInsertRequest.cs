using System.ComponentModel.DataAnnotations;


namespace AdventuraClick.Model.Requests
{
    public class UserInsertRequest
    {
        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public string FirstName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]

        [EmailAddress(), MaxLength(25)]
        public string Email { get; set; }

        [MinLength(4), MaxLength(15)]
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false), MaxLength(20)]
        public string PasswordConfirmation { get; set; }
        public int? RoleId { get; set; }
        public byte[]? Image { get; set; }
    }
}
