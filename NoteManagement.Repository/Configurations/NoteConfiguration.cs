using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteManagement.Core.Models;

namespace NoteManagement.Repository.Configurations
{
    internal class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Text).IsRequired().HasMaxLength(500);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.ToTable("Notes");

        }
    }
}
