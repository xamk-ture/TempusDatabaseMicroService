namespace DatabaseMicroService.Models
{
    public class ElectricityPriceData : BaseEntity
    {

        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }
    }
}
