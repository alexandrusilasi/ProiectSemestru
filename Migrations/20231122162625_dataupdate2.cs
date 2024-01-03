using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectSemestru.Migrations
{
    public partial class dataupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Patient_PatientID",
                table: "Consultation");

            migrationBuilder.DropIndex(
                name: "IX_Consultation_PatientID",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Consultation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "Consultation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_PatientID",
                table: "Consultation",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Patient_PatientID",
                table: "Consultation",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "Id");
        }
    }
}
