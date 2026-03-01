using System.ComponentModel.DataAnnotations;

namespace OrgMgmt.Models
{
    public class Person
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No numbers allowed")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "City is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "City name is too short or long")]
        public string Address { get; set; } = string.Empty;        
        
        public DateTime? DateOfBirth { get; set; }
        public byte[]? Photo { get; set; }
        
    }

}