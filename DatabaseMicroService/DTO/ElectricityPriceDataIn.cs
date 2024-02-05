using DatabaseMicroService.Models;
using System.Runtime.CompilerServices;

namespace DatabaseMicroService.DTO
{
    public class ElectricityPriceDataIn
    {
        public List<PriceInfo> Prices { get; set; }
    
    }

    public class PriceInfo
    {
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


}
