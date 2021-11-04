
using CentevaArchitecture.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentevaArchitecture.Infrastructure.Data.Config
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
