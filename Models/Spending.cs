namespace FundingApplication.Models
{
    public class Spending
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public double Price { get; set; }
        public bool status { get; set; }
    }
}
