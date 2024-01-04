namespace FundingApplication.Models
{
    public class MonthSalary
    {
        public Guid Id { get; set; }
        public int month { get; set; }
        public double Salary { get; set; }
        public DateTime dateOfTransaction { get; set; }      

    }
}
