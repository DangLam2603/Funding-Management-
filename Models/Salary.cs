namespace FundingApplication.Models
{
    public class Salary
    {
        public Guid Id { get; set; }
        public int year { get; set; }
        public double total { get; set; }
        public List<MonthSalary> monthSalaries { get; set; }
        public List<Spending> Spendings { get; set; }
    }
}
