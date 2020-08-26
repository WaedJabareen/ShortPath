using ShortPathAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortPathAPI.Repositories
{
    public interface IAddressRepository
    {
        List<GeoLocation> GetStoresLocation();
        List<GeoLocation> GetDronesLocation();
    }
}
