using ShortPathAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using ShortPathAPI.Repositories;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Geolocation;
using System.Device.Location;
namespace ShortPathAPI.Services
{
    public class DeliveryService : IDeliveryService
    {
        #region Public methods

        /// <summary>
        ///  calculate short path for  to deliver item to destination 
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        public DeliveryInfo CalculateShortPath(string destination)
        {
            // define delivery info object 
            DeliveryInfo deliveryInfo = null;
            // create address repository
            AddressRepository addressRepository = new AddressRepository();
            // get geo location for  destination
            GeoLocation destGeoLocation = this.GetGeoLocation(destination);
            // get drones geo location 
            List<GeoLocation> dronesGeoLocation = addressRepository.GetDronesLocation();
            // get stores geo location 
            List<GeoLocation> storesGeoLocation = addressRepository.GetStoresLocation(); ;
            // if dest exist
            if (destGeoLocation != null)
            {
                // calacute short path
                deliveryInfo = this.CalacuteShortPath(dronesGeoLocation, storesGeoLocation, destGeoLocation); ;
            }

            //return result
            return deliveryInfo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dronesGeoLocation"></param>
        /// <param name="storesGeoLocation"></param>
        /// <param name="destGeoLocation"></param>
        /// <returns></returns>
        private DeliveryInfo CalacuteShortPath(List<GeoLocation> dronesGeoLocation, List<GeoLocation> storesGeoLocation, GeoLocation destGeoLocation)
        {
            //define max value
            double shortDistance = Double.MaxValue;
            // define delivery info object 
            DeliveryInfo deliveryInfo = new DeliveryInfo();
            // go through drones location
            for (int i = 0; i < dronesGeoLocation.Count; i++)
            {
                for (int j = 0; j < storesGeoLocation.Count; j++)
                {
                    // define Geo Coordinate for drone
                    var droneCoord = new GeoCoordinate(dronesGeoLocation[i].Latitude, dronesGeoLocation[i].Longitude);
                    // define Geo Coordinate for store
                    var storeCoord = new GeoCoordinate(storesGeoLocation[j].Latitude, storesGeoLocation[j].Longitude);
                    // define Geo Coordinate for destination
                    var destCoord = new GeoCoordinate(destGeoLocation.Latitude, destGeoLocation.Longitude);
                    // get distance btw drone and store in km
                    double distance1 = droneCoord.GetDistanceTo(storeCoord) / 1000;
                    // get distance btw store and destination in km
                    double distance2 = storeCoord.GetDistanceTo(destCoord) / 1000;
                    // get total distance
                    double totaldistance = distance1 + distance2;
                    // determine short distance
                    if (totaldistance < shortDistance)
                    {
                        shortDistance = totaldistance;
                        deliveryInfo.DroneLocation = dronesGeoLocation[i].Address;
                        deliveryInfo.StoreLocation = storesGeoLocation[j].Address;
                    }
                }
            }
            //get delivery time
            deliveryInfo.DeliveryTime = this.CalacuteDeliveryTime(shortDistance);
            return deliveryInfo;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        private GeoLocation GetGeoLocation(string destination)
        {
            // create address repository
            AddressRepository addressRepository = new AddressRepository();
            // define list of testing customer locations
            List<GeoLocation> customerLocations = addressRepository.GetCustomersLocation();
            // return geo location  for destination from customer list
            return customerLocations.Where( it =>it.Address == destination).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        private string CalacuteDeliveryTime(double distance)
        {
            // get time  that drone will take in hours as speed of drone is 60km/h
            double totalTime = distance / 60;
            var timeSpan = TimeSpan.FromHours(totalTime);
            // determine minutes
            int mm = timeSpan.Minutes;
            // determine seconds
            int ss = timeSpan.Seconds;
            // return result 
            return string.Format("The Delivery Time is {0} Minutes and {1} Seconds", mm, ss);
        }
        #endregion
    }
}
