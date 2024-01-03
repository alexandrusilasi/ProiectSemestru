using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectSemestru.Migrations
{
    public partial class models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultationId",
                table: "Patient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "Consultation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    ConsultationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_Consultation_ConsultationID",
                        column: x => x.ConsultationID,
                        principalTable: "Consultation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visit_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ConsultationId",
                table: "Patient",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_PatientID",
                table: "Consultation",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_ConsultationID",
                table: "Visit",
                column: "ConsultationID");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_PatientId",
                table: "Visit",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Patient_PatientID",
                table: "Consultation",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Consultation_ConsultationId",
                table: "Patient",
                column: "ConsultationId",
                principalTable: "Consultation",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Patient_PatientID",
                table: "Consultation");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Consultation_ConsultationId",
                table: "Patient");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_Patient_ConsultationId",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Consultation_PatientID",
                table: "Consultation");

            migrationBuilder.DropColumn(
                name: "ConsultationId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Consultation");
        }
    }
}
