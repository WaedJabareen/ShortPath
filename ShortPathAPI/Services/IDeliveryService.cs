using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShortPathAPI.Models;
namespace ShortPathAPI.Services
{
    public interface IDeliveryService
    {
        /// <summary>
        /// calculate short path for  to deliver item to destination 
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        DeliveryInfo CalculateShortPath(string destination);

    }
}
