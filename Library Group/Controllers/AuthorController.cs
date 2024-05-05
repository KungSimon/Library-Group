using Library_Group.Objects;
using Library_Group.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Group.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        AuthorService authorService;

        public AuthorController(AuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public ActionResult<List<Author>> GetAllAuthors()
        {
            var authors = authorService.GetAllAuthors();
            if (authors.Count == 0)
            {
                return NoContent();
            }
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthorById(int id)
        {
            var author = authorService.GetAuthorById(id);

            if (author != null)
            {
                return Ok(author);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool success = authorService.AddAuthor(author);
            if (success)
            {
                return Ok();
            }
            return BadRequest("Failed to add the author.");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest("Mismatched author ID.");
            }

            bool success = authorService.UpdateAuthor(author);
            if (success)
            {
                return Ok();
            }
            return BadRequest("Failed to update the author.");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            var author = authorService.GetAuthorById(id);

            if (author == null)
            {
                return NotFound("Author was not found.");
            }

            if (author.Books.Any())
            {
                return Conflict("Cannot delete because of books associated with the author.");
            }

            bool success = authorService.DeleteAuthor(id);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
