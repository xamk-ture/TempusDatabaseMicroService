using DatabaseMicroService.DTO;
using DatabaseMicroService.Models;

namespace DatabaseMicroService.Extensions
{
    public static class MappingExtensions
    {
        public static ElectricityPriceData ToEntity(this PriceInfo priceInfo)
        {
            return new ElectricityPriceData
            {
                StartDate = priceInfo.StartDate,
                EndDate = priceInfo.EndDate,
                Price = priceInfo.Price
            };
        }
    }
}
