using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BarberShop_DataAccess.Data;
using BarberShop_Models.DTOs;
using BarberShop_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CustomersController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            List<Customer> services = await _db.Customers.ToListAsync();

            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUpdate([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = _mapper.Map<Customer>(customerDTO);
            if (customer.Id == 0)
            {
                await _db.Customers.AddAsync(customer);
            }
            else
            {
                _db.Customers.Update(customer);
            }

            var changes = await _db.SaveChangesAsync();
            if (changes < 1)
            {
                return StatusCode(500);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var isExist = await _db.Customers.AnyAsync(c => c.Id == id);
            if (!isExist)
            {
                return NotFound();
            }
            var customer = await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);
            _db.Customers.Remove(customer);
            var changes = await _db.SaveChangesAsync();
            if (changes < 1)
            {
                return StatusCode(500);
            }
            return Ok();
        }
    }
}
