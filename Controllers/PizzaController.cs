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
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private IApplicationDbContext _context;
        public PizzaController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Pizza pizza)
        {
            _context.Pizza.Add(pizza);
            await _context.SaveChanges();
            return Ok(pizza.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pizza = await _context.Pizza.ToListAsync();
            if (pizza == null) return NotFound();
            return Ok(pizza);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pizza = await _context.Pizza.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (pizza == null) return NotFound();
            return Ok(pizza);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pizza = await _context.Pizza.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (pizza == null) return NotFound();
            _context.Pizza.Remove(pizza);
            await _context.SaveChanges();
            return Ok(pizza.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pizza pizzaUpdate)
        {
            var pizza = _context.Pizza.Where(a => a.Id == id).FirstOrDefault();
            if (pizza == null) return NotFound();
            else
            {
                pizza.PizaaTypeId = pizzaUpdate.PizaaTypeId;
                await _context.SaveChanges();
                return Ok(pizza.Id);
            }
        }

    }
}
