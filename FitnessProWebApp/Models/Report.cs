using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FitnessProWebApp.Models
{
    public class Report
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public Dictionary<string, int> data { get; set; } = new Dictionary<string, int>();
        public bool generationComplete { get; set; } = false;
    }
}
