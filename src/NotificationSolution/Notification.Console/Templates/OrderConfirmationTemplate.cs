using Notification.Console.Core.Interfaces;
using Notification.Console.Core.Models;

namespace Notification.Console.Templates;

public class OrderConfirmationTemplate : INotificationTemplate
{
    private readonly string _orderNumber;

    public OrderConfirmationTemplate(string orderNumber)
    {
        _orderNumber = orderNumber;
    }

    public NotificationMessage CreateMessage(string recipient)
    {
        return new NotificationMessage
        {
            Recipient = recipient,
            Title = "Pedido Confirmado",
            Body = $"Seu pedido {_orderNumber} foi confirmado com sucesso!",
            IsHtml = true,
            Badge = 1
        };
    }
}