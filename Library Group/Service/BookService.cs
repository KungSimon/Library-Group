using Library_Group.Objects;

namespace Library_Group.Service
{
    public class BookService
    {
        DatabaseContext db;

        public BookService(DatabaseContext db)
        {
            this.db = db;
        }

        public List<Book> GetAllBooks()
        {
            var books = db.Book.ToList();
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = db.Book.Find(id);

            if (book == null)
            {
                return null;
            }

            return book;
        }

        public bool AddBook(Book book)
        {
            if (!db.Author.Any(a => a.Id == book.AuthorId) || !db.Category.Any(c => c.Id == book.CategoryId))
            {
                return false;
            }

            db.Book.Add(book);
            db.SaveChanges();
            return true;
        }

        public bool UpdateBook(Book updatedBook)
        {
            if (updatedBook == null || string.IsNullOrWhiteSpace(updatedBook.Title))
            {
                return false;
            }

            var book = db.Book.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (book == null)
            {
                return false;
            }

            book.Title = updatedBook.Title;
            book.Pages = updatedBook.Pages;
            book.ReleaseDate = updatedBook.ReleaseDate;

            db.SaveChanges();
            return true;
        }

        public bool DeleteBook(int id)
        {
            var book = db.Book.Find(id);
            if (book == null)
            {
                return false;
            }

            db.Book.Remove(book);
            db.SaveChanges();
            return true;
        }
    }
}