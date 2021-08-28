using Microsoft.EntityFrameworkCore.Migrations;

namespace MSH.Entities.Migrations
{
    public partial class AddingTagPropertyToQuery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Query",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Query");
        }
    }
}
