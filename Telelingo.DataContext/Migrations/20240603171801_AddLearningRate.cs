using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Telelingo.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class AddLearningRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LearningRate",
                table: "ChatWord",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LearningRate",
                table: "ChatWord");
        }
    }
}
