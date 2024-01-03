using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectSemestru.Migrations
{
    public partial class dataupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Consultation_ConsultationId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Patient_PatientId",
                table: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Patient_ConsultationId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "ConsultationId",
                table: "Patient");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Visit",
                newName: "PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_PatientId",
                table: "Visit",
                newName: "IX_Visit_PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Patient_PatientID",
                table: "Visit",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Patient_PatientID",
                table: "Visit");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Visit",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_PatientID",
                table: "Visit",
                newName: "IX_Visit_PatientId");

            migrationBuilder.AddColumn<int>(
                name: "ConsultationId",
                table: "Patient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ConsultationId",
                table: "Patient",
                column: "ConsultationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Consultation_ConsultationId",
                table: "Patient",
                column: "ConsultationId",
                principalTable: "Consultation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Patient_PatientId",
                table: "Visit",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id");
        }
    }
}
