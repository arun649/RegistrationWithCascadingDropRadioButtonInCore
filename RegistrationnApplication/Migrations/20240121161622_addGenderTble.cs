using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationnApplication.Migrations
{
    public partial class addGenderTble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "registrations");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "registrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_registrations_GenderId",
                table: "registrations",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_registrations_Genders_GenderId",
                table: "registrations",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registrations_Genders_GenderId",
                table: "registrations");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_registrations_GenderId",
                table: "registrations");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "registrations");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "registrations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
