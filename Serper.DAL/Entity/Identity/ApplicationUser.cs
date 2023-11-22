using Microsoft.AspNetCore.Identity;

namespace Serper.DAL.Entity.Identity
{
    internal sealed class ApplicationUser : IdentityUser
    {
        public ICollection<SearchRequest> SearchRequests { get; set; }
    }
}
