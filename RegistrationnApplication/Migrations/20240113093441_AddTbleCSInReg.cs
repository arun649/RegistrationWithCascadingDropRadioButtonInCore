using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationnApplication.Migrations
{
    public partial class AddTbleCSInReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "registrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "registrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_states_CountryId",
                table: "states",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_states_countries_CountryId",
                table: "states",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_states_countries_CountryId",
                table: "states");

            migrationBuilder.DropIndex(
                name: "IX_states_CountryId",
                table: "states");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "registrations");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "registrations");
        }
    }
}
