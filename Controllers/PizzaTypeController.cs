using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaviscaAssessment.Context;
using TaviscaAssessment.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaviscaAssessment.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class PizzaTypeController : ControllerBase
    {
        private IApplicationDbContext _context;
        public PizzaTypeController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(PizzaType pizzaType)
        {
            _context.PizzaType.Add(pizzaType);
            await _context.SaveChanges();
            return Ok(pizzaType.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pizzaTypes = await _context.PizzaType.ToListAsync();
            if (pizzaTypes == null) return NotFound();
            return Ok(pizzaTypes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pizzaType = await _context.PizzaType.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (pizzaType == null) return NotFound();
            return Ok(pizzaType);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pizzaType = await _context.PizzaType.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (pizzaType == null) return NotFound();
            _context.PizzaType.Remove(pizzaType);
            await _context.SaveChanges();
            return Ok(pizzaType.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PizzaType pizzaTypeUpdate)
        {
            var pizzaType = _context.PizzaType.Where(a => a.Id == id).FirstOrDefault();
            if (pizzaType == null) return NotFound();
            else
            {
                pizzaType.TypeName = pizzaTypeUpdate.TypeName;
                pizzaType.PizzaImage = pizzaTypeUpdate.PizzaImage;
                await _context.SaveChanges();
                return Ok(pizzaType.Id);
            }
        }
    }
}
