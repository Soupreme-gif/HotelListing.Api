using HotelListing.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Api.Controllers
{

    // the [controller] part is the classes's name before Controller part of the name, which in this case is "Hotels"
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : Controller
    {

        private static List<Hotel> hotels = new List<Hotel>
        {
            new Hotel { Id = 1, Name = "Grand Plaza", Address = "123 Main St", Rating = 4.5 },

            new Hotel { Id = 2, Name = "Ocean View", Address = "456 Beach Rd", Rating = 4.8 }
        };



        // GET: api/<HotelsController>
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            // this returns if the respone code is a 200 which means successful
            return Ok(hotels);
        }

        // GET: api/<HotelsController>/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var hotel = hotels.FirstOrDefault(h => h.Id == id);
            if(hotel == null)
            {
                // NotFound represents a 404 response code
                return NotFound();
            }
            // Ok represents a 200 responde code
            return Ok(hotel);
        }

        // POST: api/<HotelsController>
        [HttpPost("{id}")]
        public ActionResult<Hotel> Post([FromBody]Hotel newHotel)
        {
            if(hotels.Any(h => h.Id == newHotel.Id))
            {
                // BadRequest represents a 400 response code
                return BadRequest("A hotel with this Id already exists");
            }

            hotels.Add(newHotel);
            // CreatedAtActuion represents a 201 response code
            return CreatedAtAction(nameof(Get), new { id = newHotel.Id }, newHotel);
        }

        // Put: api/<HotelsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Hotel updatedHotel)
        {
            
            var existingHotel = hotels.FirstOrDefault(h => h.Id == id);
            if(existingHotel == null)
            {
                // NotFound represents a 404 response code
                return NotFound();
            }

            existingHotel.Name = updatedHotel.Name;
            existingHotel.Address = updatedHotel.Address;
            existingHotel.Rating = updatedHotel.Rating;

            // NoContent represent a 204 response code
            return NoContent();
        }

        // Delete: api/<HotelsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var hotel = hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                // NotFound represents a 404 response code
                return NotFound(new { message = "Hotel not found" });
            }

            hotels.Remove(hotel);
            return NoContent();
        }      
    }
}
