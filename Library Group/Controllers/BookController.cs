using Library_Group.Objects;
using Library_Group.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library_Group.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookService bookService;

        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            var books = bookService.GetAllBooks();
            if (books.Count == 0)
            {
                return NoContent();
            }
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = bookService.GetBookById(id);

            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool success = bookService.AddBook(book);
            if (success)
            {
                return Ok();
            }
            return BadRequest("Failed to add the book.");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("Mismatched book ID.");
            }

            bool success = bookService.UpdateBook(book);
            if (success)
            {
                return Ok();
            }
            return BadRequest("Failed to update the book.");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            bool success = bookService.DeleteBook(id);
            if (success)
            {
                return Ok();
            }
            return NotFound("Book was not found.");
        }
    }
}
