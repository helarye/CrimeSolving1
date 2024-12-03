using System.ComponentModel.DataAnnotations;

namespace Crime_Solving1.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int CriminalId { get; set; }
        public bool PersonalFolder { get; set; }
        public int PAlibi { get; set; }

        public ICollection<CrimeEvent> Events { get; set; }


    }
}
