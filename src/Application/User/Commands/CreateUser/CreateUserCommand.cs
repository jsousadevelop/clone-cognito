using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Commands.CreateUser;

public class CreateUserCommand : IRequest<Result<string>>
{
    public string Username { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class CreateUserCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateUserCommand, Result<string>>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<Result<string>> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken
    )
    {
        var userExists = await _context
            .Users.Where(x => x.Username == request.Username)
            .AnyAsync(cancellationToken);

        if (userExists)
            return Result<string>.Failure(["Usuário já existe."]);

        var user = new Domain.Entities.User
        {
            Username = request.Username,
            Name = request.Name,
            Password = request.Password
        };

        user.AddDomainEvent(new UserCreatedEvent(user));

        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success(user.Id);
    }
}
