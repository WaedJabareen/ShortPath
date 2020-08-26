using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortPathAPI.Models
{

    public class GeoLocation
    {
        /// <summary>
        /// Full address for location 
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Latitude of address
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// Longitude of address
        /// </summary>
        public double Longitude { get; set; }
    }
}
