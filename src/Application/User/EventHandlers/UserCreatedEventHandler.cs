using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.User.EventHandlers;

public class UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger)
    : INotificationHandler<UserCreatedEvent>
{
    private readonly ILogger<UserCreatedEventHandler> _logger = logger;

    public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "CleanArchitecture Domain Event: {DomainEvent}",
            notification.GetType().Name
        );

        return Task.CompletedTask;
    }
}
