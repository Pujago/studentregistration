
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Dtos
    {
        public class StudentCreateDto 
        {

            [Required]
            [MaxLength(250)]
            public string Name { get; set; }

        }
       
    }
    
    
    