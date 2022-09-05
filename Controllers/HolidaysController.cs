#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolidayApi.Model;
using ConsumingWebAapiRESTinMVC.Controllers;

namespace HolidayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly HolidayContext _context;

        public HolidaysController(HolidayContext context)
        {
            _context = context;
        }

        // GET: api/Holidays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Holiday>>> GetHoliday()
        {
            return await _context.Holiday.ToListAsync();
        }

        // Get Holidays Data
        [HttpGet("getholidaysdata")]
        public async Task<ActionResult<Holiday>> GetHoliDaysdata()
        {


            //Task<ActionResult<IEnumerable<Country>>> myResult = CountriesController.GetCountry();
            List<Country> countries = _context.Country.ToList();
            //foreach (Country country in countries)
            //{
            //    List<Holiday> Holidays = new List<Holiday>(HomeController.GetHolidaysFromGoogleForCountry(country.CalenderRegion, country.Id));

            //    foreach (Holiday holiday in Holidays)
            //    {
            //        _context.Holiday.Add(holiday);
            //        if (null == _context.Holiday.FirstOrDefault(te => te.GlobalId == holiday.GlobalId))
            //            await _context.SaveChangesAsync();
            //    }
            //}
            List<Holiday> Holidays = new List<Holiday>();
            foreach (Country country in countries)
            {
                List<Holiday> Holidays1 = new List<Holiday>(HomeController.GetHolidaysFromGoogleForCountry(country.CalenderRegion, country.Id));
                Holidays.AddRange(Holidays1);
                //foreach (Holiday holiday in Holidays)
                //{
                //    _context.Holiday.Add(holiday);
                //    if (null == _context.Holiday.FirstOrDefault(te => te.GlobalId == holiday.GlobalId))
                //        await _context.SaveChangesAsync();
                //}
            }
            if(_context.Holiday.Count()==0)
                {
                _context.Holiday.AddRange(Holidays);
                await _context.SaveChangesAsync();


            }
            return Ok();

        }
        // GET: api/Holidays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Holiday>> GetHoliday(int id)
        {
            var holiday = await _context.Holiday.FindAsync(id);

            if (holiday == null)
            {
                return NotFound();
            }

            return holiday;
        }
        [HttpGet("countryid/{id}")]
        public IEnumerable<Holiday> GetHolidaybyCountry(int id)
        {

            Holiday holiday = new Holiday();
            holiday.CountryId= id;
            IEnumerable<Holiday> holidays = _context.Holiday.Where(p => p.CountryId == id);
                //.GroupBy(te => te.CountryId);
                //.Select(pr => pr.CountryId )  ;

            /*if (holiday != null)
            {
                //   baaad 
                //return NotFound();
               
            }*/

            return holidays;
        }

        // PUT: api/Holidays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoliday(int id, Holiday holiday)
        {
            if (id != holiday.Id)
            {
                return BadRequest();
            }

            _context.Entry(holiday).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolidayExists(id))
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

        // POST: api/Holidays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Holiday>> PostHoliday(Holiday holiday)
        {
            _context.Holiday.Add(holiday);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoliday", new { id = holiday.Id }, holiday);
        }

        // DELETE: api/Holidays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoliday(int id)
        {
            var holiday = await _context.Holiday.FindAsync(id);
            if (holiday == null)
            {
                return NotFound();
            }

            _context.Holiday.Remove(holiday);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HolidayExists(int id)
        {
            return _context.Holiday.Any(e => e.Id == id);
        }
    }
}
