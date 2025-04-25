using Newtonsoft.Json;
using Refit;

namespace Refit_Library.Interface
{
    public interface IUserNotificationApi
    {
        [Get("/usernotification/get")]
        Task<UserNotification> GetUserNotificationAsync();
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Data
    {
        [JsonProperty("unReadCount")]
        public int UnReadCount { get; set; }

        [JsonProperty("notifications")]
        public List<Notification> Notifications { get; set; }
    }

    public class Notification
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("notificationType")]
        public int NotificationType { get; set; }

        [JsonProperty("notificationImage")]
        public object NotificationImage { get; set; }

        [JsonProperty("isRead")]
        public bool IsRead { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("clientGroupId")]
        public int ClientGroupId { get; set; }

        [JsonProperty("clientId")]
        public int ClientId { get; set; }

        [JsonProperty("createdOn")]
        public DateTime CreatedOn { get; set; }
    }

    public class UserNotification
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
