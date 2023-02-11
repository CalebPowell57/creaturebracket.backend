using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db.Migrations
{
    /// <inheritdoc />
    public partial class minorfixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoundCount",
                table: "Bracket",
                newName: "Round");

            migrationBuilder.AddColumn<long>(
                name: "Votes",
                table: "Creature",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Votes",
                table: "Creature");

            migrationBuilder.RenameColumn(
                name: "Round",
                table: "Bracket",
                newName: "RoundCount");
        }
    }
}
