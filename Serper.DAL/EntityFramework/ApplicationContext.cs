using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Serper.DAL.Entity;
using Serper.DAL.Entity.Identity;

namespace Serper.DAL.EntityFramework
{
    internal sealed class ApplicationContext : IdentityDbContext<ApplicationUser> 
    {
        public DbSet<SearchResult> Searches { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}