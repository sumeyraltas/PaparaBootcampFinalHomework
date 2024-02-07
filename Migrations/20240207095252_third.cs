using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaparaBootcampFinalHomework.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Payments_PaymentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PaymentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PaymentId",
                table: "Users",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Payments_PaymentId",
                table: "Users",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");
        }
    }
}
