using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LadisicCheng_NYCTaxi.Models;

namespace LadisicCheng_NYCTaxi.Controllers
{
    [Route("api/[controller]")]
    public class TaxiTripController : Controller
    {
        public TaxiTripController(ITaxiTripRepository taxiTrips)
        {
            TaxiTrips = taxiTrips;
        }
        public ITaxiTripRepository TaxiTrips { get; set; }
    }
}