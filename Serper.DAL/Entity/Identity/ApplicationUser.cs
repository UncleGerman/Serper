using Microsoft.AspNetCore.Identity;

namespace Serper.DAL.Entity.Identity
{
    public sealed class ApplicationUser : IdentityUser
    {
        public List<SearchResult>? SearchResults { get; set; }
    }
}