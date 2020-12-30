using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace home.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false)
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
                    { 1, "gmail 1", "cloud", "https://mail.google.com/mail/u/0/#inbox" },
                    { 18, "bitbucket", "services", "https://bitbucket.com/" },
                    { 17, "github", "services", "https://github.com/" },
                    { 16, "r/piracy", "pirating", "https://www.reddit.com/r/Piracy/wiki/megathread" },
                    { 15, "drive bypass", "pirating", "https://gdbypass.host/" },
                    { 14, "cs.rin.ru", "pirating", "https://cs.rin.ru" },
                    { 13, "fitgirl", "pirating", "http://fitgirl-repacks.site/" },
                    { 12, "rarbg", "pirating", "https://rargb.to/" },
                    { 11, "nyaa", "pirating", "https://nyaa.si/" },
                    { 10, "fake email", "pirating", "https://temp-mail.org/" },
                    { 9, "whatsapp", "social", "https://web.whatsapp.com/" },
                    { 8, "twitter", "social", "https://www.twitter.com/" },
                    { 7, "twitch", "social", "https://www.twitch.tv/directory" },
                    { 6, "reddit", "social", "https://www.reddit.com/" },
                    { 5, "youtube", "social", "https://www.youtube.com/" },
                    { 4, "gphotos", "cloud", "https://photos.google.com/?hl=es" },
                    { 3, "gdrive", "cloud", "https://drive.google.com/drive/u/0/" },
                    { 2, "gmail 2", "cloud", "https://mail.google.com/mail/u/1/#inbox" },
                    { 19, "gmaps", "services", "https://www.google.com/maps" },
                    { 20, "wetransfer", "services", "https://wetransfer.com/" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
