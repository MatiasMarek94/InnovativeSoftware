using System.Collections.Generic;
using InnovativeSoftware.Models;

namespace InnovativeSoftware.Services.Parameters
{
    public class UpdatePowerUnitParameters
    {
        public int DeviceId { get; set; }
        public PowerUnitManufacturer Manufacturer { get; set; }
        public string Name { get; set; }
        public bool On { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}