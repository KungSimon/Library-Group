using Library_Group.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library_Group.Pages
{
    public class AuthorsModel : PageModel
    {
        private readonly DatabaseContext _context;

        //Lists to store all authors and their books
        public List<Author> Authors { get; set; }
        public List<Book> Books { get; set; }

        //Holds the ID and name of selected author
        [BindProperty]
        public int SelectedAuthorId { get; set; }
        public string SelectedAuthorName { get; set; }

        public AuthorsModel(DatabaseContext context)
        {
            _context = context;
        }

        //Load all authors from database
        public void OnGet()
        {
            Authors = _context.Author.ToList();
        }

        //List all books by the selected author
        public IActionResult OnPost()
        {
            Authors = _context.Author.ToList(); 
            if (SelectedAuthorId != 0)
            {
                Books = _context.Book
                                .Where(b => b.AuthorId == SelectedAuthorId)
                                .ToList();
                SelectedAuthorName = _context.Author
                                             .Where(a => a.Id == SelectedAuthorId)
                                             .Select(a => a.Name)
                                             .FirstOrDefault(); 
            }
            return Page();
        }
    }
}
