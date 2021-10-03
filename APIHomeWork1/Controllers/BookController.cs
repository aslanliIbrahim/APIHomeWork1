using APIHomeWork1.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIHomeWork1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetBook()
        {
            var books = _context.Books.ToList();

            if (books == null) return NotFound();
            
            return Ok(books);
        }

        
        
    }
}
