using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using bookstore.bookstoreDB;
using bookstore.Controllers.Resources;
using bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Controllers
{
    [Route("/api/bookstores")]
    public class BookstoresController:Controller
    {
        private readonly IMapper mapper;
        private readonly BookstoreDbContext context;

        public BookstoresController(IMapper mapper,BookstoreDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookstoreResource>> GetBookStores()
        {
            var bookstores = await this.context.Bookstores.ToListAsync();
            return mapper.Map<IEnumerable<Bookstore>,IEnumerable<BookstoreResource>>(bookstores);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookstore([FromBody] BookstoreResource bookstoreresource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookstore = this.mapper.Map<BookstoreResource,Bookstore>(bookstoreresource);
            context.Bookstores.Add(bookstore);
            await context.SaveChangesAsync();
            return Ok(bookstore);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookstore(int id, [FromBody] BookstoreResource bookstoreResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var bookstore = await context.Bookstores.FindAsync(id); 
            if(bookstore == null)
                return NotFound();
            mapper.Map<BookstoreResource, Bookstore>(bookstoreResource, bookstore);
            await context.SaveChangesAsync();
            return Ok(bookstore);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookstore(int id)
        {
            var bookstore = await context.Bookstores.FindAsync(id);
            if(bookstore == null)
                return NotFound();
            var bookstoreResource = mapper.Map<Bookstore, BookstoreResource>(bookstore);
            return Ok(bookstoreResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookstore(int id)
        {
            var bookstore = await context.Bookstores.FindAsync(id);
            if(bookstore == null)
                return NotFound();
            context.Remove(bookstore);
            await context.SaveChangesAsync();
            return Ok(id);
        }
    }
}