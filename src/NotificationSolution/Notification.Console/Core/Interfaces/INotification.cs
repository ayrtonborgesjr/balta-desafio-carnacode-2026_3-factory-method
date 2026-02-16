using Notification.Console.Core.Models;

namespace Notification.Console.Core.Interfaces;

public interface INotification
{
    void Send(NotificationMessage message);
}