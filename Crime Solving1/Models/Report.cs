using System.ComponentModel.DataAnnotations;

namespace Crime_Solving1.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string ReporterName { get; set; }
        public int ReportedId { get; set; }
        public string ReportPlace { get; set; }
        public DateTime ReportTime { get; set; }
        public bool PastReports { get; set; }
    }
}
