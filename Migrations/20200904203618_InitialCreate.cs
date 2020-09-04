using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace home_backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "Name", "Type", "Url" },
                values: new object[,]
                {
                    { 1L, "gmail 1", "cloud", "https://mail.google.com/mail/u/0/#inbox" },
                    { 18L, "bitbucket", "services", "https://bitbucket.com/" },
                    { 17L, "github", "services", "https://github.com/" },
                    { 16L, "r/piracy", "pirating", "https://www.reddit.com/r/Piracy/wiki/megathread" },
                    { 15L, "drive bypass", "pirating", "https://gdbypass.host/" },
                    { 14L, "cs.rin.ru", "pirating", "https://cs.rin.ru" },
                    { 13L, "fitgirl", "pirating", "http://fitgirl-repacks.site/" },
                    { 12L, "rarbg", "pirating", "https://rargb.to/" },
                    { 11L, "nyaa", "pirating", "https://nyaa.si/" },
                    { 10L, "fake email", "pirating", "https://temp-mail.org/" },
                    { 9L, "whatsapp", "social", "https://web.whatsapp.com/" },
                    { 8L, "twitter", "social", "https://www.twitter.com/" },
                    { 7L, "twitch", "social", "https://www.twitch.tv/directory" },
                    { 6L, "reddit", "social", "https://www.reddit.com/" },
                    { 5L, "youtube", "social", "https://www.youtube.com/" },
                    { 4L, "gphotos", "cloud", "https://photos.google.com/?hl=es" },
                    { 3L, "gdrive", "cloud", "https://drive.google.com/drive/u/0/" },
                    { 2L, "gmail 2", "cloud", "https://mail.google.com/mail/u/1/#inbox" },
                    { 19L, "gmaps", "services", "https://www.google.com/maps" },
                    { 20L, "wetransfer", "services", "https://wetransfer.com/" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
