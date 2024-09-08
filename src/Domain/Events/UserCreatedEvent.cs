using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class UserCreatedEvent(User user) : BaseEvent
{
    public User User { get; } = user;
}
