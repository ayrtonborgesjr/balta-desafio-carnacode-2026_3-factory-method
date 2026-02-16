using Notification.Console.Core.Enums;
using Notification.Console.Core.Interfaces;

namespace Notification.Console.Services;

public class NotificationManager
{
    private readonly INotificationFactory _factory;

    public NotificationManager(INotificationFactory factory)
    {
        _factory = factory;
    }

    public void Send(
        INotificationTemplate template,
        NotificationChannel channel,
        string recipient)
    {
        var notification = _factory.Create(channel);
        var message = template.CreateMessage(recipient);

        notification.Send(message);
    }
}