using System.ComponentModel.DataAnnotations;

namespace Crime_Solving1.Models
{
    public enum GenderP
    {
        Male, Female
    }
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonTown { get; set; }
        public string PersonStreet { get; set; }
        public int PersonHouseNum { get; set; }
        public string PersonDescription { get; set; }
        public bool PersonalFolder { get; set; }
        public string PAlibi { get; set; }
        public GenderP? GenderP { get; set; }

        public ICollection<CrimeEvent> Events { get; set; }


    }
}
