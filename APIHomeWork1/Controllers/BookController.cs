using APIHomeWork1.DAL;
using APIHomeWork1.Models;
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

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetBOOKById(int id)
        {
            var books = _context.Books.FirstOrDefault(b => b.Id == id);
            if (books == null) return NotFound();

            return Ok(books);
        }
        
        [HttpPost]
        public ActionResult Create([FromBody] Book books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Books.Add(books);
            _context.SaveChanges();

            return Ok(books);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id,[FromBody] Book book)
        {
            var bookdb = _context.Books.FirstOrDefault(b => b.Id == id);

            if (bookdb is null) return NotFound();

            book.Id = bookdb.Id;
            book.Writer = bookdb.Writer;
            book.SharedDate = bookdb.SharedDate;
            book.Price = bookdb.Price;
            book.ShortAbout = bookdb.ShortAbout;
            _context.SaveChanges();

            return Ok(book);

        }
        



    }
}
