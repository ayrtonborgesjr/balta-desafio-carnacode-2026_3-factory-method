using Notification.Console.Core.Interfaces;
using Notification.Console.Core.Models;

namespace Notification.Console.Templates;

public class ShippingUpdateTemplate : INotificationTemplate
{
    private readonly string _trackingCode;

    public ShippingUpdateTemplate(string trackingCode)
    {
        _trackingCode = trackingCode;
    }

    public NotificationMessage CreateMessage(string recipient)
    {
        return new NotificationMessage
        {
            Recipient = recipient,
            Title = "Pedido Enviado",
            Body = $"Seu pedido foi enviado! Código de rastreio: {_trackingCode}",
            Badge = 1
        };
    }
}