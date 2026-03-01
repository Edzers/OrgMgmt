namespace OrgMgmt.Models
{
    public class Client : Person
    {
        public decimal Balance { get; set; }
        public List<Service> Services { get; set; } = [];
    }
}