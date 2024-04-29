using Library_Group.Objects;
using Microsoft.EntityFrameworkCore;

namespace Library_Group.Service
{
    public class AuthorService
    {
        DatabaseContext db;

        public AuthorService(DatabaseContext db)
        {
            this.db = db;
        }

        public List<Author> GetAllAuthors()
        {
            var authors = db.Author.ToList();
            return authors;
        }

        public Author GetAuthorById(int id)
        {
            var author = db.Author.Find(id);

            if (author == null)
            {
                return null;
            }

            return author;
        }

        public bool AddAuthor(Author author)
        {
            db.Author.Add(author);
            db.SaveChanges();
            return true;
        }

        public bool UpdateAuthor(Author updatedAuthor)
        {
            if (updatedAuthor == null || string.IsNullOrWhiteSpace(updatedAuthor.Name))
            {
                return false;
            }

            var author = db.Author.FirstOrDefault(a => a.Id == updatedAuthor.Id);
            if (author == null)
            {
                return false;
            }

            author.Name = updatedAuthor.Name;

            db.SaveChanges();
            return true;
        }

        public bool DeleteAuthor(int id)
        {
            var author = db.Author.Include(a => a.Books).FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return false;
            }

            if (author.Books.Any())
            {
                return false;
            }

            db.Author.Remove(author);
            db.SaveChanges();
            return true;
        }
    }
}

