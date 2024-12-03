using System.ComponentModel.DataAnnotations;

namespace Crime_Solving1.Models
{
    public class Suspect
    {
        [Key]
        public int SuspectId { get; set; }
        public string SuspectName { get; set; }
        public string SuspectDescription { get; set; }
        public int SAlibi { get; set; }

        public ICollection<CrimeEvent> CrimeEvents { get; set; }

    }
}
