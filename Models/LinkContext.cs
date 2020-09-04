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

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Link>().HasData(
                // Cloud
                new Link { Id = 1, Name = "gmail 1", Url = "https://mail.google.com/mail/u/0/#inbox", Type = "cloud" },
                new Link { Id = 2, Name = "gmail 2", Url = "https://mail.google.com/mail/u/1/#inbox", Type = "cloud" },
                new Link { Id = 3, Name = "gdrive", Url = "https://drive.google.com/drive/u/0/", Type = "cloud" },
                new Link { Id = 4, Name = "gphotos", Url = "https://photos.google.com/?hl=es", Type = "cloud" },

                // Social
                new Link { Id = 5, Name = "youtube", Url = "https://www.youtube.com/", Type = "social" },
                new Link { Id = 6, Name = "reddit", Url = "https://www.reddit.com/", Type = "social" },
                new Link { Id = 7, Name = "twitch", Url = "https://www.twitch.tv/directory", Type = "social" },
                new Link { Id = 8, Name = "twitter", Url = "https://www.twitter.com/", Type = "social" },
                new Link { Id = 9, Name = "whatsapp", Url = "https://web.whatsapp.com/", Type = "social" },

                // Pirating
                new Link { Id = 10, Name = "fake email", Url = "https://temp-mail.org/", Type = "pirating" },
                new Link { Id = 11, Name = "nyaa", Url = "https://nyaa.si/", Type = "pirating" },
                new Link { Id = 12, Name = "rarbg", Url = "https://rargb.to/", Type = "pirating" },
                new Link { Id = 13, Name = "fitgirl", Url = "http://fitgirl-repacks.site/", Type = "pirating" },
                new Link { Id = 14, Name = "cs.rin.ru", Url = "https://cs.rin.ru", Type = "pirating" },
                new Link { Id = 15, Name = "drive bypass", Url = "https://gdbypass.host/", Type = "pirating" },
                new Link { Id = 16, Name = "r/piracy", Url = "https://www.reddit.com/r/Piracy/wiki/megathread", Type = "pirating" },

                // Services
                new Link { Id = 17, Name = "github", Url = "https://github.com/", Type = "services" },
                new Link { Id = 18, Name = "bitbucket", Url = "https://bitbucket.com/", Type = "services" },
                new Link { Id = 19, Name = "gmaps", Url = "https://www.google.com/maps", Type = "services" },
                new Link { Id = 20, Name = "wetransfer", Url = "https://wetransfer.com/", Type = "services" }
            );
        }
    }
}