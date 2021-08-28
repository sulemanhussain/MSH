using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MSH.Entities.Migrations
{
    public partial class AddedCategoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Query",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ParentCategoryID = table.Column<int>(type: "int", nullable: true),
                    GUID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsertBy = table.Column<int>(type: "int", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Query_CategoryID",
                table: "Query",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Query_Category_CategoryID",
                table: "Query",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Query_Category_CategoryID",
                table: "Query");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Query_CategoryID",
                table: "Query");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Query");
        }
    }
}
