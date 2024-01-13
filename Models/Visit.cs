using ProiectSemestru.Migrations;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace ProiectSemestru.Models
{
    public class Visit
    {
        public int Id { get; set; }


        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public int number { get; set; }
        public Patient? Patient { get; set; }
        public int? PatientID { get; set; }

        public int? ConsultationID { get; set; }
        public Consultation? Consultation { get; set; }

        public int? DoctorID { get; set; }
        public Doctor? Doctor { get; set; }

        public ICollection<Prescription>? Prescriptions { get; set; }

        public string DisplayInfo => $"{date.ToShortDateString()} - {Patient?.firstName} {Patient?.lastName}";
    }
}
