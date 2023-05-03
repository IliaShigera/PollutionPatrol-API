namespace PollutionPatrol.BuildingBlocks.Notification.Abstractions;

public interface INotificationSender<in TMessage> where TMessage : INotificationMessage
{
    Task SendNotificationAsync(TMessage message, CancellationToken cancellationToken = default);
}