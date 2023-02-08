using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db.Migrations
{
    /// <inheritdoc />
    public partial class smallchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Seed",
                table: "Creature",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Phase",
                table: "Bracket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seed",
                table: "Creature");

            migrationBuilder.AlterColumn<long>(
                name: "Phase",
                table: "Bracket",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
