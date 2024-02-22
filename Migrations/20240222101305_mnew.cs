using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageLIbrary.Migrations
{
    /// <inheritdoc />
    public partial class mnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChanellChanellSource");

            migrationBuilder.CreateIndex(
                name: "IX_ChanellSources_ChanellId",
                table: "ChanellSources",
                column: "ChanellId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChanellSources_Chanells_ChanellId",
                table: "ChanellSources",
                column: "ChanellId",
                principalTable: "Chanells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChanellSources_Chanells_ChanellId",
                table: "ChanellSources");

            migrationBuilder.DropIndex(
                name: "IX_ChanellSources_ChanellId",
                table: "ChanellSources");

            migrationBuilder.CreateTable(
                name: "ChanellChanellSource",
                columns: table => new
                {
                    SourcesId = table.Column<int>(type: "int", nullable: false),
                    chanellId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChanellChanellSource", x => new { x.SourcesId, x.chanellId });
                    table.ForeignKey(
                        name: "FK_ChanellChanellSource_ChanellSources_SourcesId",
                        column: x => x.SourcesId,
                        principalTable: "ChanellSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChanellChanellSource_Chanells_chanellId",
                        column: x => x.chanellId,
                        principalTable: "Chanells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChanellChanellSource_chanellId",
                table: "ChanellChanellSource",
                column: "chanellId");
        }
    }
}
