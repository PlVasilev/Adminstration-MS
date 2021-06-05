using System.ComponentModel.DataAnnotations;

namespace Administration.Server.Features.Identity
{
    public class LoginUserRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
