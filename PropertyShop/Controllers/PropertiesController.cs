using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyShop.Data;
using PropertyShop.Models;
using PropertyShop.Repositories;

namespace PropertyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertyShopDbContext _context;
        private readonly IPropertiesRepository _propertiesRepository;

        public PropertiesController(IPropertiesRepository propertiesRepository)
        {
            _propertiesRepository = propertiesRepository;
        }

        // GET: api/Properties
        [HttpGet]
        public async Task<IEnumerable<Property>> GetProperties()
        {
            return await _propertiesRepository.GetAllProperties();
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            var @property = await _propertiesRepository.GetSingleProperty(id);

            if (@property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(int id, Property @property)
        {
            if (id != @property.id)
            {
                return BadRequest();
            }

            await _propertiesRepository.UpdateProperty(property);
            return NoContent();
        }

        // POST: api/Properties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Property>> PostProperty(Property @property)
        {
            _propertiesRepository.CreateProperty(property);

            return CreatedAtAction("GetProperty", new { id = @property.id }, @property);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            _propertiesRepository.DeleteProperty(id);

            return NoContent();
        }
    }
}
