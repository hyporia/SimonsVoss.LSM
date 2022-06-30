using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimonsVoss.LSM.DB.Migrations
{
    public partial class add_indexes_for_buildings_media_groups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region building
            
            migrationBuilder.Sql(
                "CREATE INDEX idx_building_lower_case_name ON buildings ((lower(name))) WHERE name IS NOT NULL;");
            
            migrationBuilder.Sql(
                "CREATE INDEX idx_building_lower_case_description ON buildings ((lower(description))) WHERE description IS NOT NULL;");
            
            migrationBuilder.Sql(
                "CREATE INDEX idx_building_lower_case_short_cut ON buildings ((lower(short_cut))) WHERE short_cut IS NOT NULL;");

            #endregion

            #region medium

            migrationBuilder.Sql(
                "CREATE INDEX idx_medium_lower_case_owner ON media ((lower(owner))) WHERE owner IS NOT NULL;");
            
            migrationBuilder.Sql(
                "CREATE INDEX idx_medium_lower_case_serial_number ON media ((lower(serial_number))) WHERE serial_number IS NOT NULL;");
            
            migrationBuilder.Sql(
                "CREATE INDEX idx_medium_lower_case_description ON media ((lower(description))) WHERE description IS NOT NULL;");

            #endregion
            
            #region group

            migrationBuilder.Sql(
                "CREATE INDEX idx_group_lower_case_name ON groups ((lower(name))) WHERE name IS NOT NULL;");
            
            migrationBuilder.Sql(
                "CREATE INDEX idx_group_lower_case_description ON groups ((lower(description))) WHERE description IS NOT NULL;");

            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //drop indexes...
        }
    }
}
