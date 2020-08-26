using ShortPathAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortPathAPI.Repositories
{
    public class AddressRepository : IAddressRepository
    {

        /// <summary>
        /// Retuen list of supply goods location
        /// </summary>
        /// <returns></returns>
        public  List<GeoLocation> GetDronesLocation()
        {
            return new List<GeoLocation> { new GeoLocation (){ Address = "Metrostrasse 12, 40235 Düsseldorf",Latitude=51.2351265, Longitude=6.8255114},
                                           new GeoLocation (){ Address ="Ludenberger Str. 1, 40629 Düsseldorf",Latitude=51.2413724, Longitude=6.8303233 } };

        }
        /// <summary>
        /// Retuen list of supply goods location
        /// </summary>
        /// <returns></returns>
        public List<GeoLocation> GetStoresLocation()
        {
            return new List<GeoLocation> {  new GeoLocation (){ Address = "Willstätterstraße 24, 40549 Düsseldorf",Latitude=51.2399951,Longitude=6.7189236 },
                                        new GeoLocation (){ Address ="Bilker Allee 128, 40217 Düsseldorf",Latitude=51.2107917,Longitude=6.7743871 },
                                        new GeoLocation (){ Address = "Hammer Landstraße 113, 41460 Neuss",Latitude=51.2035317,Longitude=6.7211437 },
                                        new GeoLocation (){ Address = "Gladbacher Str. 471, 41460 Neuss",Latitude=51.2252158,Longitude=6.6905132},
                                        new GeoLocation (){ Address = "Lise-Meitner-Straße 1, 40878 Ratingen",Latitude=51.2959417,Longitude=6.829789 } };


        }
        /// <summary>
        /// Retuen list of supply goods location
        /// </summary>
        /// <returns></returns>
        public List<GeoLocation> GetCustomersLocation()
        {
            return new List<GeoLocation>() { new GeoLocation { Address = "Friedrichstraße 133, 40217 Düsseldorf", Latitude = 51.2083899, Longitude = 6.7743807 },
                                             new GeoLocation { Address = "Fischerstraße 23, 40477 Düsseldorf", Latitude = 51.2366051, Longitude = 6.7771461 },
                                             new GeoLocation { Address = "Wildenbruchstraße 2, 40545 Düsseldorf", Latitude = 51.2294622, Longitude = 6.7469827 },
                                             new GeoLocation { Address = "Reisholzer Str. 48, 40231 Düsseldorf", Latitude = 51.2068462, Longitude = 6.8323711 },

                                            };
        }
    }
}
