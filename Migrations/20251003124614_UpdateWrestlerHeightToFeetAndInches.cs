using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wwe_universe_manager.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWrestlerHeightToFeetAndInches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Wrestler",
                newName: "WeightInPounds");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Wrestler",
                newName: "HeightInInches");

            migrationBuilder.AddColumn<int>(
                name: "HeightInFeet",
                table: "Wrestler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeightInFeet",
                table: "Wrestler");

            migrationBuilder.RenameColumn(
                name: "WeightInPounds",
                table: "Wrestler",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "HeightInInches",
                table: "Wrestler",
                newName: "Height");
        }
    }
}
