using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SimonsVoss.LSM.DB.Migrations
{
    public partial class add_searching_weights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "searching_weight",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entity_name = table.Column<string>(type: "text", nullable: false),
                    property_name = table.Column<string>(type: "text", nullable: false),
                    transitive_entity_name = table.Column<string>(type: "text", nullable: true),
                    weight = table.Column<int>(type: "integer", nullable: false),
                    full_match_multiplier = table.Column<int>(type: "integer", nullable: false, defaultValue: 10)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_searching_weight", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "searching_weight",
                columns: new[] { "id", "entity_name", "full_match_multiplier", "property_name", "transitive_entity_name", "weight" },
                values: new object[,]
                {
                    { 1, "Lock", 10, "Name", null, 10 },
                    { 2, "Lock", 10, "LockType", null, 3 },
                    { 3, "Lock", 10, "SerialNumber", null, 8 },
                    { 4, "Lock", 10, "Floor", null, 6 },
                    { 5, "Lock", 10, "RoomNumber", null, 6 },
                    { 6, "Lock", 10, "Description", null, 6 },
                    { 7, "Lock", 10, "Name", "Building", 8 },
                    { 8, "Lock", 10, "ShortCut", "Building", 5 },
                    { 9, "Medium", 10, "MediumType", null, 3 },
                    { 10, "Medium", 10, "Owner", null, 10 },
                    { 11, "Medium", 10, "SerialNumber", null, 8 },
                    { 12, "Medium", 10, "Description", null, 6 },
                    { 13, "Medium", 10, "Name", "Group", 8 },
                    { 14, "Building", 10, "Name", null, 9 },
                    { 15, "Building", 10, "ShortCut", null, 7 },
                    { 16, "Building", 10, "Description", null, 5 },
                    { 17, "Group", 10, "Name", null, 9 },
                    { 18, "Group", 10, "Description", null, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "searching_weight",
                schema: "public");
        }
    }
}
