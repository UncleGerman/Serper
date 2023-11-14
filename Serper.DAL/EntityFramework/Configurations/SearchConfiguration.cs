using Serper.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Serper.DAL.EntityFramework.Configurations
{
    internal class SearchConfiguration : IEntityTypeConfiguration<Search>
    {
        public void Configure(EntityTypeBuilder<Search> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Query).IsRequired();
            builder.Property(s => s.Position).IsRequired();
            builder.Property(s => s.DescriptionLink).IsRequired();
        }
    }
}