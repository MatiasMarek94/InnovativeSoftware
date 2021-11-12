using System;

namespace InnovativeSoftware.Repositories.Models
{
    public class Co2Emission
    {
        public int CO2Emission { get; set; }
        public DateTime Minutes5UTC { get; set; }
        public DateTime Minutes5DK { get; set; }
        public long _id { get; set; }
        public string PriceArea { get; set; }
    }
}