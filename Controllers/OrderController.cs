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
    public class OrderController : ControllerBase
    {
        private IApplicationDbContext _context;
        public OrderController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChanges();
            return Ok(order.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order = await _context.Order.ToListAsync();
            if (order == null) return NotFound();
            return Ok(order);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _context.Order.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (order == null) return NotFound();
            return Ok(order);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _context.Order.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (order == null) return NotFound();
            _context.Order.Remove(order);
            await _context.SaveChanges();
            return Ok(order.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Order orderUpdate)
        {
            var order = _context.Order.Where(a => a.Id == id).FirstOrDefault();
            if (order == null) return NotFound();
            else
            {
                order.PizzaId = orderUpdate.PizzaId;
                order.OrderStatus = orderUpdate.OrderStatus;
                await _context.SaveChanges();
                return Ok(order.Id);
            }
        }
    }
}
