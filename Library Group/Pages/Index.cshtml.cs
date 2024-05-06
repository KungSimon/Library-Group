using Microsoft.AspNetCore.Mvc.RazorPages;
using Library_Group.Objects; 

public class IndexModel : PageModel
{
    private readonly DatabaseContext _context;

    public List<Book> Books { get; set; }

    public IndexModel(DatabaseContext context)
    {
        _context = context;
    }

    //Load all books from database
    public void OnGet()
    {
        Books = _context.Book.ToList(); 
    }
}
