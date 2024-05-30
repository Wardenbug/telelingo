using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telelingo.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWordEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Word",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Word",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Word",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Word");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Word");
        }
    }
}
