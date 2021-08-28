using Microsoft.EntityFrameworkCore.Migrations;

namespace MSH.Entities.Migrations
{
    public partial class RemovedApplicationTypeFromQueryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Query_ApplicationType_ApplicationTypeID",
                table: "Query");

            migrationBuilder.DropIndex(
                name: "IX_Query_ApplicationTypeID",
                table: "Query");

            migrationBuilder.DropColumn(
                name: "ApplicationTypeID",
                table: "Query");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationTypeID",
                table: "Query",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Query_ApplicationTypeID",
                table: "Query",
                column: "ApplicationTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Query_ApplicationType_ApplicationTypeID",
                table: "Query",
                column: "ApplicationTypeID",
                principalTable: "ApplicationType",
                principalColumn: "ApplicationTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
