using Refit_Library.Services;
using System.Net.Http.Headers;

namespace Refit_Library.Handler
{
    public class AuthenticatedHttpClientHandler : DelegatingHandler
    {
        private readonly IServiceProvider _provider;

        public AuthenticatedHttpClientHandler(IServiceProvider provider)
        {
            _provider = provider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Resolve scoped service to fetch token
            using var scope = _provider.CreateScope();
            var tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();

            var token = await tokenService.GetAccessTokenAsync();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken);
        }
    }

}
