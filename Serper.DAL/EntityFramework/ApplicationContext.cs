using Serper.DAL.Entity;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Serper.DAL.EntityFramework
{
    internal sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Search> Searches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}