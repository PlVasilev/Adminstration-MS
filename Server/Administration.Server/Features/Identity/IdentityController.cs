using System.Linq;

namespace Administration.Server.Features.Identity
{
    using System.Threading.Tasks;
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IIdentityService _identityService;

        public IdentityController(UserManager<User> userManager,
            IOptions<AppSettings> appSettings, 
            IIdentityService identityService)
        {
            _userManager = userManager;
            _identityService = identityService;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new User
            {
                UserName = model.Username,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (_userManager.Users.Count() == 1)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            await _userManager.AddToRoleAsync(user, "User");

            if (result.Succeeded) return Ok();
            
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginUserRequestModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null) return Unauthorized();

            var passwordValid = _userManager.CheckPasswordAsync(user, model.Password);
            if (passwordValid == null) return Unauthorized();

            var roles = await this._userManager.GetRolesAsync(user);

            return _identityService.GenerateJwtToken(user.Id, user.UserName, _appSettings.Secret, roles);
        }
    }
}
