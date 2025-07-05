using BankBlazor.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly BankBlazorContext _context;

        public CustomersController(BankBlazorContext context)
        {
            _context = context;
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer == null ? NotFound() : customer;
        }

        // GET api/customers/5/accounts
        [HttpGet("{id}/accounts")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts(int id)
        {
            var accounts = await _context.Accounts
                .Where(a => a.Dispositions.Any(d => d.CustomerId == id))
                .ToListAsync();
            return accounts;
        }
    }
} 