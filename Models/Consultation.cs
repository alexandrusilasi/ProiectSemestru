namespace ProiectSemestru.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<Visit>? Visits { get; set; }
    }
}
