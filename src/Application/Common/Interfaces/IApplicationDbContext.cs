using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.User> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
