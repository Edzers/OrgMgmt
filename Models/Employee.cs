namespace OrgMgmt.Models
{
    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public List<Service> Services { get; set; } = [];
        public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
    }

}