using System;
using System.Collections.Generic;

namespace InnovativeSoftware.Models
{
    public class PowerUnit
    {
        // Did not know which key to use, so I created a Guid for it
        public Guid PowerUnitId { get; set; }
        public int DeviceId { get; set; }
        public PowerUnitManufacturer Manufacturer { get; set; }
        public string Name { get; set; }
        public bool On { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}