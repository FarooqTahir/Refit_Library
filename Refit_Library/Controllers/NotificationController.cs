using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit_Library.Interface;

namespace Refit_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IUserNotificationApi _userNotificationApi;

        public NotificationController(IUserNotificationApi userNotificationApi)
        {
            _userNotificationApi = userNotificationApi;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            var user = await _userNotificationApi.GetUserNotificationAsync();
            return Ok(user);
        }
    }
}
