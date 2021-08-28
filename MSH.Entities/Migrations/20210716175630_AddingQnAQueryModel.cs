using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MSH.Entities.Migrations
{
    public partial class AddingQnAQueryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distribution",
                columns: table => new
                {
                    DistributionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    GUID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribution", x => x.DistributionID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationType",
                columns: table => new
                {
                    ApplicationTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AppCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistributionID = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationType", x => x.ApplicationTypeID);
                    table.ForeignKey(
                        name: "FK_ApplicationType_Distribution_DistributionID",
                        column: x => x.DistributionID,
                        principalTable: "Distribution",
                        principalColumn: "DistributionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationType_DistributionID",
                table: "ApplicationType",
                column: "DistributionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationType");

            migrationBuilder.DropTable(
                name: "Distribution");
        }
    }
}
