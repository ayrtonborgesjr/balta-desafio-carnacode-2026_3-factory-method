using Notification.Console.Core.Enums;
using Notification.Console.Factories;
using Notification.Console.Services;
using Notification.Console.Templates;

var factory = new NotificationFactory();
var manager = new NotificationManager(factory);

// Pedido confirmado
var orderTemplate = new OrderConfirmationTemplate("12345");
manager.Send(orderTemplate, NotificationChannel.Email, "cliente@email.com");

// Atualização de envio
var shippingTemplate = new ShippingUpdateTemplate("BR123456789");
manager.Send(shippingTemplate, NotificationChannel.Push, "device-token-abc");

// Lembrete de pagamento
var paymentTemplate = new PaymentReminderTemplate(150.00m);
manager.Send(paymentTemplate, NotificationChannel.WhatsApp, "+551199999999");