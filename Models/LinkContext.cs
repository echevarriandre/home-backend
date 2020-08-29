using Microsoft.EntityFrameworkCore;

namespace home_backend.Models
{
    public class LinkContext : DbContext
    {
        public LinkContext(DbContextOptions<LinkContext> options)
            : base(options)
        {
        }

        public DbSet<Link> Links { get; set; }
    }
}