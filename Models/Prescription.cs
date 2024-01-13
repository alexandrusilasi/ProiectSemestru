namespace ProiectSemestru.Models
{
    public class Prescription
    {
        public int Id { get; set; }

        public int? VisitID { get; set; }

        public Visit? Visit { get; set; }

        public string Content { get; set; }
    }
}
