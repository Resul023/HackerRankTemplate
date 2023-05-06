using HackTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace HackTest.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Product> Products { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
