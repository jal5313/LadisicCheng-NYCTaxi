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

        [HttpGet]
        public IEnumerable<TaxiTrip> GetAll()
        {
            return TaxiTrips.GetAll();
        }

        [HttpGet("{id}", Name = "GetTrip")]
        public IActionResult GetById(string id)
        {
            var item = TaxiTrips.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TaxiTrip item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            TaxiTrips.Add(item);
            return CreatedAtRoute("GetTrip", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TaxiTrip item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = TaxiTrips.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            TaxiTrips.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todo = TaxiTrips.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            TaxiTrips.Remove(id);
            return new NoContentResult();
        }
    }
}