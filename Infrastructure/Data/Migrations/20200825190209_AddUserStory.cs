using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddUserStory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_ResourceTypes_ResourceTypeId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_ResourceTypeId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Devision",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Discovery",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "InScope",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "ResourceTypeId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Features");

            migrationBuilder.AddColumn<int>(
                name: "HoursPerWeek",
                table: "ResourceTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "ResourceTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "UserStory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Devision = table.Column<string>(nullable: true),
                    ServiceDiscipline = table.Column<string>(nullable: true),
                    Discovery = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Design = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Implementation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Test = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResourceTypeId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStory_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStory_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStory_FeatureId",
                table: "UserStory",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStory_ResourceTypeId",
                table: "UserStory",
                column: "ResourceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStory");

            migrationBuilder.DropColumn(
                name: "HoursPerWeek",
                table: "ResourceTypes");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "ResourceTypes");

            migrationBuilder.AddColumn<decimal>(
                name: "Design",
                table: "Features",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Devision",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discovery",
                table: "Features",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "InScope",
                table: "Features",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ResourceTypeId",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Test",
                table: "Features",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Features_ResourceTypeId",
                table: "Features",
                column: "ResourceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_ResourceTypes_ResourceTypeId",
                table: "Features",
                column: "ResourceTypeId",
                principalTable: "ResourceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
