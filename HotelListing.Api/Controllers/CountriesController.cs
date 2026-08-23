using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Api.Data;
using HotelListing.Api;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly HotelListingDbContext _context;
    public CountriesController(HotelListingDbContext context)
    {
        _context = context;
    }

    // GET: api/Country
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Country>>> GetCountry()
    {
        return await _context.Countries.ToListAsync();
    }

    // GET: api/Country/5
    [HttpGet("{countryid}")]
    public async Task<ActionResult<Country>> GetCountry(int countryid)
    {
        var country = await _context.Countries.FindAsync(countryid);

        if (country == null)
        {
            return NotFound();
        }

        return country;
    }

    // PUT: api/Country/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{countryid}")]
    public async Task<IActionResult> PutCountry(int? countryid, Country country)
    {
        if (countryid != country.CountryId)
        {
            return BadRequest();
        }

        _context.Entry(country).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryExists(countryid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Country
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Country>> PostCountry(Country country)
    {
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCountry", new { countryid = country.CountryId }, country);
    }

    // DELETE: api/Country/5
    [HttpDelete("{countryid}")]
    public async Task<IActionResult> DeleteCountry(int? countryid)
    {
        var country = await _context.Countries.FindAsync(countryid);
        if (country == null)
        {
            return NotFound();
        }

        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CountryExists(int? countryid)
    {
        return _context.Countries.Any(e => e.CountryId == countryid);
    }
}
