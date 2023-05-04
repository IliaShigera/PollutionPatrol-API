namespace PollutionPatrol.Modules.UserAccess.Application.Features.Registration.Expiration;

internal sealed class SendExpirationEmailNotification : IDomainEventHandler<UserRegistrationExpiredDomainEvent>
{
    private readonly IEmailNotificationSender _emailNotificationSender;

    public SendExpirationEmailNotification(IEmailNotificationSender emailNotificationSender) =>
        _emailNotificationSender = emailNotificationSender;

    public async Task Handle(UserRegistrationExpiredDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        // todo: replace logic of generation message content 
        StringBuilder builder = new("<html><body>");
        builder.Append("<p>Hey there!</p>");
        builder.Append("<p> We wanted to let you know that your registration for Pollution Patrol has expired." +
                       " Unfortunately, you'll need to sign up again to continue using our service.!</p>");
        builder.Append("<p>If you have any questions or issues, please reach out to us anytime.</p>");
        builder.Append("<p>Thanks for considering Pollution Patrol!</p>");
        builder.Append("</body></html>");

        EmailNotificationMessage emailMessage = new(
            To: (domainEvent.FirstName, domainEvent.EmailAddress),
            Subject: "Pollution Patrol - Your Registration has Expired",
            Content: String.Concat(builder),
            ContentFormat.Html
        );

        await _emailNotificationSender.SendNotificationAsync(emailMessage, cancellationToken);
    }
}