namespace Notification.Console.Core.Models;

public class NotificationMessage
{
    public string Recipient { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    // Opcional – útil para Push
    public int? Badge { get; set; }

    // Opcional – útil para WhatsApp/Email HTML
    public bool IsHtml { get; set; }
}