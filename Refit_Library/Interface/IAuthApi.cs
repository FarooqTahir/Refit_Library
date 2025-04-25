using Newtonsoft.Json;
using Refit;

namespace Refit_Library.Interface
{
    public interface IAuthApi
    {
        [Post("/auth/login")]
        Task<AuthResponse> GetTokenAsync([Body] LoginRequest loginData);
        public class LoginRequest
        {
            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }
        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Data
        {
            [JsonProperty("accessToken")]
            public string AccessToken { get; set; }

            [JsonProperty("refreshToken")]
            public string RefreshToken { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("roleName")]
            public string RoleName { get; set; }

            [JsonProperty("userId")]
            public int UserId { get; set; }

            [JsonProperty("profileImage")]
            public string ProfileImage { get; set; }

            [JsonProperty("isWarehouseAssociated")]
            public bool IsWarehouseAssociated { get; set; }

            [JsonProperty("claims")]
            public List<string> Claims { get; set; }
        }

        public class AuthResponse
        {
            [JsonProperty("data")]
            public Data Data { get; set; }

            [JsonProperty("totalCount")]
            public int TotalCount { get; set; }

            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("isSuccess")]
            public bool IsSuccess { get; set; }

            [JsonProperty("errors")]
            public List<object> Errors { get; set; }

            [JsonProperty("validationErrors")]
            public List<object> ValidationErrors { get; set; }

            [JsonProperty("message")]
            public object Message { get; set; }

            [JsonProperty("errorId")]
            public object ErrorId { get; set; }
        }
    }
}
