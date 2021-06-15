namespace Administration.Server.Features.Identity
{
    using System.Collections.Generic;
    public interface IIdentityService
    {
        public LoginResponseModel GenerateJwtToken(string userId, string userName, string appSecret, IEnumerable<string> roles);
    }
}
