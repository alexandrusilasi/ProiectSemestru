namespace ProiectSemestru.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Visit>? Visits { get; set; }
    }
}
