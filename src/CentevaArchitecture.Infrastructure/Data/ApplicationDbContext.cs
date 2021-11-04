using System.Reflection;
using CentevaArchitecture.Domain;
using CentevaArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CentevaArchitecture.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IPublisher _domainEventPublisher;

        public DbSet<TodoItem> TodoItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher domainEventPublisher) : base(options)
        {
            _domainEventPublisher = domainEventPublisher;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            await DispatchDomainEvents();

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        private async Task DispatchDomainEvents()
        {
            if (_domainEventPublisher == null) return;

            var entitiesWithEvents = ChangeTracker
                .Entries()
                .Select(e => e.Entity as BaseEntity)
                .Where(e => e?.DomainEvents != null && e.DomainEvents.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.DomainEvents.ToArray();
                entity.DomainEvents.Clear();
                foreach (var domainEvent in events)
                {
                    await _domainEventPublisher.Publish(domainEvent).ConfigureAwait(false);
                }
            }
        }
    }
}
