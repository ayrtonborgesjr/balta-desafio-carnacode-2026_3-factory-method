using Notification.Console.Core.Enums;

namespace Notification.Console.Core.Interfaces;

public interface INotificationFactory
{
    INotification Create(NotificationChannel channel);
}