using Notification.Console.Core.Interfaces;
using Notification.Console.Core.Models;

namespace Notification.Console.Notifications.Email;

public class EmailNotification : INotification
{
    public void Send(NotificationMessage message)
    {
        System.Console.WriteLine("📧 EMAIL");
        System.Console.WriteLine($"Para: {message.Recipient}");
        System.Console.WriteLine($"Título: {message.Title}");
        System.Console.WriteLine($"HTML: {message.IsHtml}");
        System.Console.WriteLine($"Mensagem: {message.Body}");
        System.Console.WriteLine("----------------------------");
    }
}