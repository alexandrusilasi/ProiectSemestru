namespace ProiectSemestru.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string phone { get; set; }
    
        public string cnp { get; set; }

        public ICollection<Visit>? Visits { get; set; }
    }
}
