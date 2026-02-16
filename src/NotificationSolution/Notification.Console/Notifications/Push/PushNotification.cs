using Notification.Console.Core.Interfaces;
using Notification.Console.Core.Models;

namespace Notification.Console.Notifications.Push;

public class PushNotification : INotification
{
    public void Send(NotificationMessage message)
    {
        System.Console.WriteLine("🔔 PUSH");
        System.Console.WriteLine($"Device: {message.Recipient}");
        System.Console.WriteLine($"Título: {message.Title}");
        System.Console.WriteLine($"Badge: {message.Badge}");
        System.Console.WriteLine($"Mensagem: {message.Body}");
        System.Console.WriteLine("----------------------------");
    }
}