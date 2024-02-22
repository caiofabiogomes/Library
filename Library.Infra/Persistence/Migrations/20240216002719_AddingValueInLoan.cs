using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddingValueInLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValuePerDay",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValuePerDayLate",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValuePerDay",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "ValuePerDayLate",
                table: "Loans");
        }
    }
}
