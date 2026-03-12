using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSessionAddSessionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "Dur",
                table: "Sessions",
                newName: "Duration");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Sessions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Sessions",
                newName: "Dur");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sessions",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
