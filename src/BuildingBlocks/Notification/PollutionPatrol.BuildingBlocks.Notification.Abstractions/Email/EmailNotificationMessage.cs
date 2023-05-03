namespace PollutionPatrol.BuildingBlocks.Notification.Abstractions.Email;

public sealed record EmailNotificationMessage(
    (string Name, string EmailAddress) To,
    string Subject,
    string Content,
    ContentFormat ContentFormat
) : INotificationMessage;