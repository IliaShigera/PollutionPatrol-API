namespace PollutionPatrol.BuildingBlocks.Notification.Email;

internal sealed class EmailNotificationSender : INotificationSender<EmailNotificationMessage>
{
    private readonly EmailOptions _emailOptions;

    public EmailNotificationSender(IOptions<EmailOptions> options) => _emailOptions = options.Value;

    public async Task SendNotificationAsync(EmailNotificationMessage message, CancellationToken cancellationToken = default)
    {
        var emailNotification = new MimeMessage();
        emailNotification.From.Add(new MailboxAddress(_emailOptions.Name, _emailOptions.EmailAddress));
        emailNotification.To.Add(new MailboxAddress(message.To.Name, message.To.EmailAddress));
        emailNotification.Subject = message.Subject;
        emailNotification.Body = new TextPart(DefineTextFormat(message.ContentFormat))
        {
            Text = message.Content
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_emailOptions.Host, _emailOptions.Port, useSsl: false, cancellationToken);
        await smtp.AuthenticateAsync(userName: _emailOptions.EmailAddress, _emailOptions.Password, cancellationToken);
        await smtp.SendAsync(emailNotification, cancellationToken);
        await smtp.DisconnectAsync(quit: true, cancellationToken);
    }

    private TextFormat DefineTextFormat(ContentFormat contentFormat) => contentFormat switch
    {
        ContentFormat.Text => TextFormat.Text,
        ContentFormat.Html => TextFormat.Html,
        _ => TextFormat.Text
    };
}