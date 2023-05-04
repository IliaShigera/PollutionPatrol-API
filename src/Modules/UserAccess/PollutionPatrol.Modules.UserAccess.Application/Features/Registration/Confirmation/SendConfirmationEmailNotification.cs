namespace PollutionPatrol.Modules.UserAccess.Application.Features.Registration.Confirmation;

internal sealed class SendConfirmationEmailNotification : IDomainEventHandler<NewUserRegistrationCreatedDomainEvent>
{
    private readonly IEmailNotificationSender _emailNotificationSender;

    public SendConfirmationEmailNotification(IEmailNotificationSender emailNotificationSender) =>
        _emailNotificationSender = emailNotificationSender;

    public async Task Handle(NewUserRegistrationCreatedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        // todo: get the link
        var confirmationLink = $"<a href=\"/api/registration/confirm?confirmationCode={domainEvent.ConfirmationCode}\">click here</a>";

        // todo: replace logic of generation message content 
        StringBuilder builder = new("<html><body>");
        builder.Append("<p>Hey there!</p>");
        builder.Append("<p>Thanks for signing up for Pollution Patrol! To complete your registration, please use this confirmation code:</p>");
        builder.Append($"<p>{domainEvent.ConfirmationCode}</p>");
        builder.Append("<p>Or, you can also confirm your registration by clicking the link below:</p>");
        builder.Append($"<p>{confirmationLink}</p>");
        builder.Append("<p>If you have any questions or issues, please reach out to us anytime.</p>");
        builder.Append("<p>Thanks again for joining us!</p>");
        builder.Append("</body></html>");

        EmailNotificationMessage notification = new(
            To: (domainEvent.FirstName, domainEvent.EmailAddress),
            Subject: "Pollution Patrol - Please confirm your registration",
            Content: string.Concat(builder),
            ContentFormat.Html
        );

        await _emailNotificationSender.SendNotificationAsync(notification, cancellationToken);
    }
}