using Library_Group.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library_Group.Pages
{
    public class CategoriesModel : PageModel
    {
        private readonly DatabaseContext _context;

        //Lists to store all categories and their books
        public List<Category> Categories { get; set; }
        public List<Book> Books { get; set; }

        //Holds the ID and name of selected category
        [BindProperty]
        public int SelectedCategoryId { get; set; }
        public string SelectedCategoryName { get; set; }

        public CategoriesModel(DatabaseContext context)
        {
            _context = context;
        }

        //Load all categories from database
        public void OnGet()
        {
            Categories = _context.Category.ToList();
        }

        //List all books in the selected category
        public IActionResult OnPost()
        {
            Categories = _context.Category.ToList();
            if (SelectedCategoryId != 0)
            {
                Books = _context.Book
                                .Where(b => b.CategoryId == SelectedCategoryId)
                                .ToList();
                SelectedCategoryName = _context.Category
                                               .Where(c => c.Id == SelectedCategoryId)
                                               .Select(c => c.Name)
                                               .FirstOrDefault();
            }
            return Page();
        }
    }
}
