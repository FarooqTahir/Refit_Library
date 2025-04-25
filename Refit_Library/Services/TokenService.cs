using Refit_Library.Interface;
using static Refit_Library.Interface.IAuthApi;

namespace Refit_Library.Services
{
    public interface ITokenService
    {
        Task<string> GetAccessTokenAsync();
    }

    public class TokenService : ITokenService
    {
        private readonly IAuthApi _authApi;
        private string _cachedToken;
        private DateTime _expiresAt;

        public TokenService(IAuthApi authApi)
        {
            _authApi = authApi;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            if (!string.IsNullOrEmpty(_cachedToken) && _expiresAt > DateTime.UtcNow)
                return _cachedToken;

            var loginData = new LoginRequest
        {
           Email = "example@gmail.com",
           Password = "bbV0!Ij?85M_"

            };

            var response = await _authApi.GetTokenAsync(loginData);
            _cachedToken = response.Data.AccessToken;
            _expiresAt = DateTime.UtcNow.AddDays(1);

            return _cachedToken;
        }
    }

}
