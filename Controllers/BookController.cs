using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_LZS.Models;

namespace WebAPI_LZS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _dbContext;

        public BookController(BookContext dbContext)
        {
            _dbContext = dbContext;
        }

        //untuk senaraikan semua data buku
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBook()
        {
            if(_dbContext.Books == null)
            {
                return NotFound();
            }
            return await _dbContext.Books.ToListAsync();
        }

        //untuk dapat satu jenis rekod buku sahaja
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookDetail(int id)
        {
            if(_dbContext.Books == null)
            {
                return NotFound();
            }

            var book = await _dbContext.Books.FindAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            return book;
        }

        // tambah satu rekod baru buku
        [HttpPost]
        public async Task<ActionResult<Book>> AddBookRecord(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBookDetail), new { id = book.Id}, book);
        }

        // Put Method 
        [HttpPut]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if(id != book.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(book).State = EntityState.Modified; 
            
            try {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool BooksExists(long id)
        {
            return (_dbContext.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // padam rekod
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_dbContext.Books == null)
            {
                return NotFound();
            }

            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }


    }
}
