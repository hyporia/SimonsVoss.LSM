using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimonsVoss.LSM.DB.Migrations
{
    public partial class locks_create_indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_locks_lock_type_lock_type_id",
                schema: "public",
                table: "locks");

            migrationBuilder.DropForeignKey(
                name: "fk_media_medium_type_medium_type_id",
                schema: "public",
                table: "media");

            migrationBuilder.AddForeignKey(
                name: "fk_locks_lock_types_lock_type_id",
                schema: "public",
                table: "locks",
                column: "lock_type_id",
                principalSchema: "public",
                principalTable: "lock_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_media_medium_types_medium_type_id",
                schema: "public",
                table: "media",
                column: "medium_type_id",
                principalSchema: "public",
                principalTable: "medium_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            // EF Core model builder doesn't support expression, indexes as far as I know
            migrationBuilder.Sql(
                "CREATE INDEX idx_lock_lower_case_name ON locks ((lower(name))) WHERE name IS NOT NULL;");
            
            migrationBuilder.Sql(
                "CREATE INDEX idx_lock_lower_case_description ON locks ((lower(description))) WHERE description IS NOT NULL;");
            
            migrationBuilder.Sql(
                "CREATE INDEX idx_lock_lower_case_serial_number ON locks ((lower(serial_number))) WHERE serial_number IS NOT NULL;");
            
            migrationBuilder.Sql(
                "CREATE INDEX idx_lock_lower_case_floor ON locks ((lower(floor))) WHERE floor IS NOT NULL;");
            
            migrationBuilder.Sql(
                "CREATE INDEX idx_lock_lower_case_room_number ON locks ((lower(room_number))) WHERE room_number IS NOT NULL;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_locks_lock_types_lock_type_id",
                schema: "public",
                table: "locks");

            migrationBuilder.DropForeignKey(
                name: "fk_media_medium_types_medium_type_id",
                schema: "public",
                table: "media");

            migrationBuilder.AddForeignKey(
                name: "fk_locks_lock_type_lock_type_id",
                schema: "public",
                table: "locks",
                column: "lock_type_id",
                principalSchema: "public",
                principalTable: "lock_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_media_medium_type_medium_type_id",
                schema: "public",
                table: "media",
                column: "medium_type_id",
                principalSchema: "public",
                principalTable: "medium_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
