using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Telelingo.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Word",
                columns: new[] { "WordId", "Key", "Priority", "Value" },
                values: new object[,]
                {
                    { 1L, "kto", 1, "хто" },
                    { 2L, "čo", 1, "що" },
                    { 3L, "aký, aká, aké", 1, "який, яка, яке" },
                    { 4L, "ten, tá, to", 1, "цей, ця, це; той, та, те" },
                    { 5L, "tento, táto, toto", 1, "цей, ця, це" },
                    { 6L, "nejaký , nejaká, nejaké", 1, "якийсь, якась, якесь" },
                    { 7L, "auto", 1, "автомобіль" },
                    { 8L, "dedko", 1, "дідусь" },
                    { 9L, "dieťa", 1, "дитина" },
                    { 10L, "dom", 1, "дім, будинок" },
                    { 11L, "doma", 1, "вдома" },
                    { 12L, "futbalista", 1, "футболіст" },
                    { 13L, "kniha", 1, "книга" },
                    { 14L, "kosť", 1, "кістка" },
                    { 15L, "kvet", 1, "квітка" },
                    { 16L, "lekáreň", 1, "аптека" },
                    { 17L, "mačka", 1, "кішка" },
                    { 18L, "múzeum", 1, "музей" },
                    { 19L, "muž", 1, "чоловік" },
                    { 20L, "námestie", 1, "Міська площа" },
                    { 21L, "pes", 1, "собака" },
                    { 22L, "posteľ", 1, "ліжко" },
                    { 23L, "ruža", 1, "троянда" },
                    { 24L, "srdce", 1, "серце" },
                    { 25L, "šteňa", 1, "щеня" },
                    { 26L, "žena", 1, "жінка" },
                    { 27L, "je", 1, "є" },
                    { 28L, "veľmi", 1, "дуже, вельми" },
                    { 29L, "vysoký", 1, "високий" },
                    { 30L, "nízky", 1, "низький" },
                    { 31L, "veľký", 1, "великий" },
                    { 32L, "malý", 1, "малий" },
                    { 33L, "pekný", 1, "гарний" },
                    { 34L, "krásny", 1, "красивий" },
                    { 35L, "dobrý", 1, "добрий" },
                    { 36L, "nový", 1, "новий" },
                    { 37L, "starý", 1, "старий" },
                    { 38L, "moderný", 1, "сучасний" },
                    { 39L, "červený", 1, "червоний" },
                    { 40L, "zelený", 1, "зелений" },
                    { 41L, "čierny", 1, "чорний" },
                    { 42L, "biely", 1, "білий" },
                    { 43L, "modrý", 1, "синій" },
                    { 44L, "žltý", 1, "жовтий" },
                    { 45L, "tam", 1, "там" },
                    { 46L, "tu", 1, "тут" },
                    { 47L, "a", 1, "і; та" },
                    { 48L, "alebo", 1, "або" },
                    { 49L, "ja som ...", 1, "Я є ..." },
                    { 50L, "ty si ...", 1, "Ти є ..." },
                    { 51L, "on/ona/ono je ...", 1, "він/вона/воно є ..." },
                    { 52L, "my sme ...", 1, "ми є ..." },
                    { 53L, "vy ste ...", 1, "Ви є ..." },
                    { 54L, "oni/ony sú ...", 1, "вони є ..." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Word",
                keyColumn: "WordId",
                keyValue: 54L);
        }
    }
}
