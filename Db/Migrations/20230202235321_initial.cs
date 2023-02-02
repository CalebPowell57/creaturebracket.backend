using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bracket",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoundCount = table.Column<long>(type: "bigint", nullable: false),
                    CreatureCount = table.Column<long>(type: "bigint", nullable: false),
                    Phase = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bracket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Creature",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BracketId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creature_Bracket_BracketId",
                        column: x => x.BracketId,
                        principalTable: "Bracket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatureSubmission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BracketId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureSubmission_Bracket_BracketId",
                        column: x => x.BracketId,
                        principalTable: "Bracket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matchup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Round = table.Column<long>(type: "bigint", nullable: false),
                    Rank = table.Column<long>(type: "bigint", nullable: false),
                    WinnerId = table.Column<long>(type: "bigint", nullable: true),
                    Creature1Id = table.Column<long>(type: "bigint", nullable: true),
                    Creature2Id = table.Column<long>(type: "bigint", nullable: true),
                    BracketId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchup_Bracket_BracketId",
                        column: x => x.BracketId,
                        principalTable: "Bracket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matchup_Creature_Creature1Id",
                        column: x => x.Creature1Id,
                        principalTable: "Creature",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchup_Creature_Creature2Id",
                        column: x => x.Creature2Id,
                        principalTable: "Creature",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchup_Creature_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Creature",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserMatchup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Round = table.Column<long>(type: "bigint", nullable: false),
                    Rank = table.Column<long>(type: "bigint", nullable: false),
                    WinnerId = table.Column<long>(type: "bigint", nullable: true),
                    Creature1Id = table.Column<long>(type: "bigint", nullable: true),
                    Creature2Id = table.Column<long>(type: "bigint", nullable: true),
                    BracketId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMatchup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMatchup_Bracket_BracketId",
                        column: x => x.BracketId,
                        principalTable: "Bracket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMatchup_Creature_Creature1Id",
                        column: x => x.Creature1Id,
                        principalTable: "Creature",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMatchup_Creature_Creature2Id",
                        column: x => x.Creature2Id,
                        principalTable: "Creature",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMatchup_Creature_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Creature",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CreatureSubmissionVote",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatureSubmissionId = table.Column<long>(type: "bigint", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureSubmissionVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatureSubmissionVote_CreatureSubmission_CreatureSubmissionId",
                        column: x => x.CreatureSubmissionId,
                        principalTable: "CreatureSubmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Creature_BracketId",
                table: "Creature",
                column: "BracketId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureSubmission_BracketId",
                table: "CreatureSubmission",
                column: "BracketId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatureSubmissionVote_CreatureSubmissionId",
                table: "CreatureSubmissionVote",
                column: "CreatureSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchup_BracketId",
                table: "Matchup",
                column: "BracketId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchup_Creature1Id",
                table: "Matchup",
                column: "Creature1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matchup_Creature2Id",
                table: "Matchup",
                column: "Creature2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matchup_WinnerId",
                table: "Matchup",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMatchup_BracketId",
                table: "UserMatchup",
                column: "BracketId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMatchup_Creature1Id",
                table: "UserMatchup",
                column: "Creature1Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserMatchup_Creature2Id",
                table: "UserMatchup",
                column: "Creature2Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserMatchup_WinnerId",
                table: "UserMatchup",
                column: "WinnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureSubmissionVote");

            migrationBuilder.DropTable(
                name: "Matchup");

            migrationBuilder.DropTable(
                name: "UserMatchup");

            migrationBuilder.DropTable(
                name: "CreatureSubmission");

            migrationBuilder.DropTable(
                name: "Creature");

            migrationBuilder.DropTable(
                name: "Bracket");
        }
    }
}
