using Notification.Console.Core.Interfaces;
using Notification.Console.Core.Models;

namespace Notification.Console.Notifications.Sms;

public class SmsNotification : INotification
{
    public void Send(NotificationMessage message)
    {
        System.Console.WriteLine("📱 SMS");
        System.Console.WriteLine($"Número: {message.Recipient}");
        System.Console.WriteLine($"Mensagem: {message.Body}");
        System.Console.WriteLine("----------------------------");
    }
}