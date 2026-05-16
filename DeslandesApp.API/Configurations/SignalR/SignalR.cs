using Microsoft.AspNetCore.SignalR;

namespace DeslandesApp.API.SignalR
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            var userId =
                connection.User?.FindFirst("unique_name")?.Value;

            Console.WriteLine($"USER ID PROVIDER: {userId}");

            return userId;
        }
    }
}