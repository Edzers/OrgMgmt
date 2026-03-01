using System.ComponentModel.DataAnnotations;

namespace OrgMgmt.Models
{
    public class Service
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; }
        
        [Range(0, Double.MaxValue, ErrorMessage = "Rate cannot be negative")]
        public decimal Rate { get; set; }
        
        //Relationships
        public List<Client> Clients { get; set; } = [];
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }

}