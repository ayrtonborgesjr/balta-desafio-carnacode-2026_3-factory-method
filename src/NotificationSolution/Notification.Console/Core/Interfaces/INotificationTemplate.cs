using Notification.Console.Core.Models;

namespace Notification.Console.Core.Interfaces;

public interface INotificationTemplate
{
    NotificationMessage CreateMessage(string recipient);
}