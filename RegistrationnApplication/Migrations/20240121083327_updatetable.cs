using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationnApplication.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registrations_states_StateId",
                table: "registrations");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "registrations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_registrations_states_StateId",
                table: "registrations",
                column: "StateId",
                principalTable: "states",
                principalColumn: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registrations_states_StateId",
                table: "registrations");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "registrations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_registrations_states_StateId",
                table: "registrations",
                column: "StateId",
                principalTable: "states",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
