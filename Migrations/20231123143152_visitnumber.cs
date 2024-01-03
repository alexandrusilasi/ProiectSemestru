using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectSemestru.Migrations
{
    public partial class visitnumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "number",
                table: "Visit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number",
                table: "Visit");
        }
    }
}
