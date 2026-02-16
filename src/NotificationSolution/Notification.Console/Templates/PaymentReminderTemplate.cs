using Notification.Console.Core.Interfaces;
using Notification.Console.Core.Models;

namespace Notification.Console.Templates;

public class PaymentReminderTemplate : INotificationTemplate
{
    private readonly decimal _amount;

    public PaymentReminderTemplate(decimal amount)
    {
        _amount = amount;
    }

    public NotificationMessage CreateMessage(string recipient)
    {
        return new NotificationMessage
        {
            Recipient = recipient,
            Title = "Lembrete de Pagamento",
            Body = $"Você possui um pagamento pendente de R$ {_amount:N2}",
            IsHtml = false
        };
    }
}