namespace Administration.Server.Features.Identity
{
    public interface IIdentityService
    {
        public LoginResponseModel GenerateJwtToken(string userId, string userName, string appSecret);
    }
}
