using System.ComponentModel.DataAnnotations;

namespace CrudWebApp.Models
{
    public class Candidates
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        
        public DateTime Date_Of_Birth { get; set; }

        
        public int Age { get; set; }
        


        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
