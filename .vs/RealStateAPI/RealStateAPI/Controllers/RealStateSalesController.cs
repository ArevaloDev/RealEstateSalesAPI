using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealStateAPI.Models;

namespace RealStateAPI.Controllers
{
    [Route("/api[controller]")]
    [ApiController]

    public class RealStateSalesController : ControllerBase
    {
        private readonly RealStateSalesContext _context;
        public RealStateSalesController(RealStateSalesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HousingLocation>>> GetRealStateSales()
        {
            return await _context.HousingLocations.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<HousingLocation>> SendHousingLocation(HousingLocation body)
        {
            _context.HousingLocations.Add(body);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRealStateSales), new
            {
                id = body.Id,
                name = body.Name,
                city = body.City,
                state = body.State,
                photo = body.Photo,
                availableUnits = body.AvailableUnits,
                wifi = body.Wifi,
                laundry = body.Laundry

            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HousingLocation>> UpdateHousingLocation(int id, HousingLocation body)
        {
            if(id != body.Id)
            {
                return BadRequest();
            }
            _context.Entry(body).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!_context.HousingLocations.Any(e => e.Id == id))
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
    }
}
