using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuraClick.Model.Requests
{
    public class ProfileUpdateRequest
    {
        [MaxLength(20)]
        public string? FirstName { get; set; }
        [ MaxLength(20)]
        public string? LastName { get; set; }
        [MaxLength(20)]
        public string? Password { get; set; }
        [MaxLength(20)]
        public string? PasswordConfirmation { get; set; }
        public byte[]? Image { get; set; }
        public string? ImageString { get; set; }

    }
}
