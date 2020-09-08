using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class UpdateDivision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Devision",
                table: "UserStory");

            migrationBuilder.AddColumn<string>(
                name: "Division",
                table: "UserStory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Division",
                table: "UserStory");

            migrationBuilder.AddColumn<string>(
                name: "Devision",
                table: "UserStory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
