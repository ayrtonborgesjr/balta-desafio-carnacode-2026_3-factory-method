using Notification.Console.Templates;

namespace Notification.Tests.Templates;

public class PaymentReminderTemplateTests
{
    [Fact]
    public void CreateMessage_ShouldReturnCorrectMessage()
    {
        // Arrange
        var amount = 150.00m;
        var recipient = "+5511999999999";
        var template = new PaymentReminderTemplate(amount);

        // Act
        var message = template.CreateMessage(recipient);

        // Assert
        Assert.NotNull(message);
        Assert.Equal(recipient, message.Recipient);
        Assert.Equal("Lembrete de Pagamento", message.Title);
        Assert.Contains("pagamento pendente", message.Body);
        Assert.Contains("150,00", message.Body);
        Assert.False(message.IsHtml);
    }

    [Fact]
    public void CreateMessage_WithDifferentAmount_ShouldFormatAmountCorrectly()
    {
        // Arrange
        var amount = 1234.56m;
        var template = new PaymentReminderTemplate(amount);

        // Act
        var message = template.CreateMessage("test@test.com");

        // Assert
        Assert.Contains("1.234,56", message.Body);
    }

    [Fact]
    public void CreateMessage_WithSmallAmount_ShouldFormatCorrectly()
    {
        // Arrange
        var amount = 9.99m;
        var template = new PaymentReminderTemplate(amount);

        // Act
        var message = template.CreateMessage("test@test.com");

        // Assert
        Assert.Contains("9,99", message.Body);
    }

    [Fact]
    public void CreateMessage_ShouldSetIsHtmlToFalse()
    {
        // Arrange
        var template = new PaymentReminderTemplate(100m);

        // Act
        var message = template.CreateMessage("test@test.com");

        // Assert
        Assert.False(message.IsHtml);
    }
}

