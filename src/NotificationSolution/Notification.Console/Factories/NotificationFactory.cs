using Notification.Console.Core.Enums;
using Notification.Console.Core.Interfaces;
using Notification.Console.Notifications.Email;
using Notification.Console.Notifications.Push;
using Notification.Console.Notifications.Sms;
using Notification.Console.Notifications.WhatsApp;

namespace Notification.Console.Factories;

public class NotificationFactory : INotificationFactory
{
    public INotification Create(NotificationChannel channel)
    {
        return channel switch
        {
            NotificationChannel.Email => new EmailNotification(),
            NotificationChannel.Sms => new SmsNotification(),
            NotificationChannel.Push => new PushNotification(),
            NotificationChannel.WhatsApp => new WhatsAppNotification(),
            _ => throw new ArgumentException("Canal inválido")
        };
    }
}