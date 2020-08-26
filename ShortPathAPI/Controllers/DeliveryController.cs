using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortPathAPI.Models;
using ShortPathAPI.Services;

namespace ShortPathAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deliveryService"></param>
        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }
        
        // GET api/<Delivery>/address
        [HttpGet("{address}")]
        public object Get(string address)
        {
            if (address == null)
            {
                return BadRequest();
            }
            // Calculate short path to pick item from store to customer
            var shortpath = _deliveryService.CalculateShortPath(address);
            if (shortpath == null)
            {
                return BadRequest();
            }

            // return short path
            return shortpath;
        }

    }
}
