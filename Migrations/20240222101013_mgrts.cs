using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageLIbrary.Migrations
{
    /// <inheritdoc />
    public partial class mgrts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Card",
                table: "Chanells");

            migrationBuilder.DropColumn(
                name: "EmrCode",
                table: "Chanells");

            migrationBuilder.DropColumn(
                name: "ErrorMesage",
                table: "Chanells");

            migrationBuilder.DropColumn(
                name: "Port",
                table: "Chanells");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Chanells",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ChanellName",
                table: "Chanells",
                newName: "NameOfChanell");

            migrationBuilder.CreateTable(
                name: "ChanellSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceName = table.Column<string>(name: "Source Name", type: "nvarchar(max)", nullable: false),
                    FormatOfSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceStrean = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChanellId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChanellSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfPackage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChanellID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Chanells_ChanellID",
                        column: x => x.ChanellID,
                        principalTable: "Chanells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Desclambers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emr = table.Column<int>(type: "int", nullable: false),
                    Card = table.Column<int>(type: "int", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    ChanellSourceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desclambers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desclambers_ChanellSources_ChanellSourceID",
                        column: x => x.ChanellSourceID,
                        principalTable: "ChanellSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reciever",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emr = table.Column<int>(type: "int", nullable: false),
                    Card = table.Column<int>(type: "int", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    ChanellSourceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reciever", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reciever_ChanellSources_ChanellSourceID",
                        column: x => x.ChanellSourceID,
                        principalTable: "ChanellSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statuss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    ChanellSourceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuss_ChanellSources_ChanellSourceID",
                        column: x => x.ChanellSourceID,
                        principalTable: "ChanellSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transcoders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emr = table.Column<int>(type: "int", nullable: false),
                    Card = table.Column<int>(type: "int", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    ChanellSourceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcoders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transcoders_ChanellSources_ChanellSourceID",
                        column: x => x.ChanellSourceID,
                        principalTable: "ChanellSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChanellChanellSource_chanellId",
                table: "ChanellChanellSource",
                column: "chanellId");

            migrationBuilder.CreateIndex(
                name: "IX_Desclambers_ChanellSourceID",
                table: "Desclambers",
                column: "ChanellSourceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ChanellID",
                table: "Packages",
                column: "ChanellID");

            migrationBuilder.CreateIndex(
                name: "IX_Reciever_ChanellSourceID",
                table: "Reciever",
                column: "ChanellSourceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statuss_ChanellSourceID",
                table: "Statuss",
                column: "ChanellSourceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transcoders_ChanellSourceID",
                table: "Transcoders",
                column: "ChanellSourceID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChanellChanellSource");

            migrationBuilder.DropTable(
                name: "Desclambers");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Reciever");

            migrationBuilder.DropTable(
                name: "Statuss");

            migrationBuilder.DropTable(
                name: "Transcoders");

            migrationBuilder.DropTable(
                name: "ChanellSources");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Chanells",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "NameOfChanell",
                table: "Chanells",
                newName: "ChanellName");

            migrationBuilder.AddColumn<int>(
                name: "Card",
                table: "Chanells",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmrCode",
                table: "Chanells",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMesage",
                table: "Chanells",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Port",
                table: "Chanells",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
