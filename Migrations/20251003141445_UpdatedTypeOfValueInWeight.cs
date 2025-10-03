using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wwe_universe_manager.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTypeOfValueInWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "WeightInPounds",
                table: "Wrestler",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WeightInPounds",
                table: "Wrestler",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
