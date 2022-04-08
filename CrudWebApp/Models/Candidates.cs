using System.ComponentModel.DataAnnotations;

namespace CrudWebApp.Models
{
    public class CandidatesLi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? First_Name { get; set; }

        [Required]
        public string? Last_Name { get; set; }

        [Required]
        public DateTime Date_Of_Birth { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
