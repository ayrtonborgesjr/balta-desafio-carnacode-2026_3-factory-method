using Notification.Console.Core.Interfaces;
using Notification.Console.Core.Models;

namespace Notification.Console.Notifications.WhatsApp;

public class WhatsAppNotification : INotification
{
    public void Send(NotificationMessage message)
    {
        System.Console.WriteLine("💬 WHATSAPP");
        System.Console.WriteLine($"Telefone: {message.Recipient}");
        System.Console.WriteLine($"Mensagem: {message.Body}");
        System.Console.WriteLine("----------------------------");
    }
}