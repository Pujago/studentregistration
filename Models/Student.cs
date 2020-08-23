using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class Student 
    {
        [Key]
        public int Id {get; set;}
        
        [Required]
        [MaxLength(250)]
        public string Name {get; set;}
    }
}