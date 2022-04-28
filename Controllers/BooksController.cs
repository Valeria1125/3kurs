using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cousework_3_kurs.db;
using couse_work_web.ModelsApi;

namespace Cousework_3_kurs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly cousework3kursContext _context;

        public BooksController(cousework3kursContext context)
        {
            _context = context;
        }

        // GET: api/Books/name
        [HttpPost("search")]
        public async Task<ActionResult<List<BookApi>>> FindBooks(SearchBook search)
        {
            var books = await _context.Books.Where(s => s.TitleBook.Contains(search.SearchName)).ToListAsync();
            /*if (search.Year != -1)
                books = books.Where(s => s.Year == search.Year).ToList();*/
            return books.Select( s=> GetBookApi(s.Id,s).Result).ToList();

        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookApi>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            BookApi result = await GetBookApi(id, book);

            return result;
        }

        private async Task<BookApi> GetBookApi(int id, Book book)
        {
            var result = (BookApi)book;

            var cross = _context.BookAuthors.Where(s => s.IdBook == id);
            result.Authors = await cross.Select(s => _context.Authors.FirstOrDefault(d => d.Id == s.IdAuthor)).Select(s => (AuthorApi)s).ToListAsync();
            var crossGenre = _context.BookGenres.Where(s => s.IdBook == id);
            result.Genres = await crossGenre.Select(s => _context.Genres.FirstOrDefault(d => d.Id == s.IdGenre)).Select(s => (GenreApi)s).ToListAsync();
            var crossPublish = _context.BookPublishes.Where(s => s.IdBook == id);
            result.Publishes = await crossPublish.Select(s =>
            new PublishData
            {
                Date = s.YearOfPublication,
                Publish = (PublishingApi)_context.Publishings.FirstOrDefault(d => d.Id == s.IdPublish)
            }).ToListAsync();
            return result;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookApi book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var oldbook = await _context.Books.FindAsync(id);
            oldbook.TitleBook = book.TitleBook;

            _context.Entry(oldbook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookApi>> PostBook(BookApi book)
        {
            var newBook = (Book)book;

            _context.Books.Add(newBook);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookExists(book.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            int id = newBook.Id;
            book.Authors.ForEach(async s => await _context.BookAuthors.AddAsync(new BookAuthor { IdAuthor = s.Id, IdBook = id }));
            book.Genres.ForEach(async s => await _context.BookGenres.AddAsync(new BookGenre { IdGenre = s.Id, IdBook = id }));
            book.Publishes.ForEach(async s => await _context.BookPublishes.AddAsync(new BookPublish { IdPublish = s.Publish.Id, YearOfPublication = s.Date, IdBook = id }));
            await _context.SaveChangesAsync();

            BookApi result = await GetBookApi(id, newBook);
            return result;
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
