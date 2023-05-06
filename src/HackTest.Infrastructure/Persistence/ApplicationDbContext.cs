using Duende.IdentityServer.EntityFramework.Options;
using HackTest.Application.Common.Interfaces;
using HackTest.Domain.Entities;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace HackTest.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration<Country>(new CountryConfiguration());
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
