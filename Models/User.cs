using System.ComponentModel.DataAnnotations;

namespace FundingApplication.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }       
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int age { get; set; }
        public DateTime StartedDate { get; set; }
        public List<Salary> salaries { get; set; }
    }
}
