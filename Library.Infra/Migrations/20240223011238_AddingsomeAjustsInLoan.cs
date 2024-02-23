using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddingsomeAjustsInLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalValuePaid",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "TotalValuePaid",
                table: "Loans");
        }
    }
}
