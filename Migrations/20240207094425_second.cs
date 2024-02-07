using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaparaBootcampFinalHomework.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Apartments_UserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Apartments_ApartmentId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ApartmentId1",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonthlyExpenses",
                table: "MonthlyExpenses");

            migrationBuilder.DropColumn(
                name: "ApartmentId1",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MonthlyExpenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "MonthlyExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "MonthlyExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonthlyExpenses",
                table: "MonthlyExpenses",
                columns: new[] { "Year", "Month" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApartmentId",
                table: "Users",
                column: "ApartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PaymentId",
                table: "Users",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Year_Month",
                table: "Payments",
                columns: new[] { "Year", "Month" });

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_MonthlyExpenses_Year_Month",
                table: "Payments",
                columns: new[] { "Year", "Month" },
                principalTable: "MonthlyExpenses",
                principalColumns: new[] { "Year", "Month" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                table: "Users",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Payments_PaymentId",
                table: "Users",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_MonthlyExpenses_Year_Month",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Apartments_ApartmentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Payments_PaymentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ApartmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PaymentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Payments_Year_Month",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonthlyExpenses",
                table: "MonthlyExpenses");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "MonthlyExpenses");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "MonthlyExpenses");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentId1",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Payments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MonthlyExpenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonthlyExpenses",
                table: "MonthlyExpenses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApartmentId1",
                table: "Users",
                column: "ApartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Apartments_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "Apartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Apartments_ApartmentId1",
                table: "Users",
                column: "ApartmentId1",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
