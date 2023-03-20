using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class Pet
    {
        [Key]   
        public Guid PetId { get; set; }
        public string PetName { get; set; }
        public int PetWeight { get; set; }

        public string PetType { get; set;}
        
        
    }
}
