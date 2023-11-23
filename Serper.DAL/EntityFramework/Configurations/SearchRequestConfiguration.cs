using Serper.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Serper.DAL.EntityFramework.Configurations
{
    internal class SearchRequestConfiguration : IEntityTypeConfiguration<SearchRequest>
    {
        public void Configure(EntityTypeBuilder<SearchRequest> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Query).IsRequired();
            builder.Property(s => s.Position).IsRequired();
            builder.Property(s => s.DescriptionLink).IsRequired();
        }
    }
}