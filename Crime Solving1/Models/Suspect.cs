using System.ComponentModel.DataAnnotations;
using Humanizer;

namespace Crime_Solving1.Models
{
    public enum Gender
    {
        Male,Female 
    }
    public class Suspect
    {
        [Key]
        public int SuspectId { get; set; }
        public string SuspectFname { get; set; }
        public string SuspectLname { get; set; }
        public string SuspectDescription { get; set; }
        public string SuspectTown { get; set; }
        public string SuspectStreet { get; set; }
        public int SuspectHouseNum { get; set; }
        public string SAlibi { get; set; }
        public Gender? Gender  {get; set;}
        public bool CriminalFolder { get; set; }

        public ICollection<CrimeEvent> CrimeEvents { get; set; }

    }
}
