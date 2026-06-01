using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafeTrack.AuthService.Migrations
{
    /// <inheritdoc />
    public partial class AddGeofenceCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Geofences",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Geofences",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Geofences");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Geofences");
        }
    }
}
