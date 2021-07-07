using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaviscaAssessment.Context;
using TaviscaAssessment.Models;

namespace TaviscaAssessment.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private IApplicationDbContext _context;
        public IngredientController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ingredients ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChanges();
            return Ok(ingredient.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ingredients = await _context.Ingredients.ToListAsync();
            if (ingredients == null) return NotFound();
            return Ok(ingredients);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ingredient = await _context.Ingredients.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (ingredient == null) return NotFound();
            return Ok(ingredient);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ingredient = await _context.Ingredients.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (ingredient == null) return NotFound();
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChanges();
            return Ok(ingredient.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ingredients ingredientUpdate)
        {
            var ingredient = _context.Ingredients.Where(a => a.Id == id).FirstOrDefault();
            if (ingredient == null) return NotFound();
            else
            {
                ingredient.Name = ingredientUpdate.Name;
                ingredient.Price = ingredientUpdate.Price;
                ingredient.Image = ingredientUpdate.Image;
                await _context.SaveChanges();
                return Ok(ingredient.Id);
            }
        }
    }
}
