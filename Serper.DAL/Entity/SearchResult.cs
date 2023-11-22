using Serper.DAL.Entity.Identity;

namespace Serper.DAL.Entity
{
    public sealed class SearchResult
    {
        public string Id { get; set; }

        public int Position {  get; set; }

        public string? Query { get; set; }

        public string? Link { get; set; }

        public ICollection<ApplicationUser>? Users { get; set; }
    }
}