using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortPathAPI.Models
{
    public class DeliveryInfo
    {
        /// <summary>
        /// Drone Location
        /// </summary>
        public string DroneLocation { get; set; }
        /// <summary>
        /// Store Location
        /// </summary>
        public string StoreLocation { get; set; }
        /// <summary>
        /// Delivery Time
        /// </summary>
        public string DeliveryTime { get; set; }

    }
}
