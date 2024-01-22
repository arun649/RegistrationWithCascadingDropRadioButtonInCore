using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationnApplication.Migrations
{
    public partial class changetbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_registrations_CountryId",
                table: "registrations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_registrations_StateId",
                table: "registrations",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_registrations_countries_CountryId",
                table: "registrations",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_registrations_states_StateId",
                table: "registrations",
                column: "StateId",
                principalTable: "states",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registrations_countries_CountryId",
                table: "registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_registrations_states_StateId",
                table: "registrations");

            migrationBuilder.DropIndex(
                name: "IX_registrations_CountryId",
                table: "registrations");

            migrationBuilder.DropIndex(
                name: "IX_registrations_StateId",
                table: "registrations");
        }
    }
}
