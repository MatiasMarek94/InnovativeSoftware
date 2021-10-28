using System;

namespace InnovativeSoftware.Repositories.Models
{
    public class ElspotPrice
    {
        public double SpotPriceEUR { get; set; }
        public DateTime HourUTC { get; set; }
        public DateTime HourDK { get; set; }
        public long _id { get; set; }
        public string PriceArea { get; set; }
        public double SpotPriceDKK { get; set; }
    }
}