using Library_Group.Objects;
using Microsoft.EntityFrameworkCore;

namespace Library_Group.Service
{
    public class CategoryService
    {
        DatabaseContext db;

        public CategoryService(DatabaseContext db)
        {
            this.db = db;
        }

        public List<Category> GetAllCategories()
        {
            var categories = db.Category.ToList();
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            var category = db.Category.Find(id);

            if (category == null)
            {
                return null;
            }

            return category;
        }

        public bool AddCategory(Category category)
        {
            db.Category.Add(category);
            db.SaveChanges();
            return true;
        }

        public bool UpdateCategory(Category updatedCategory)
        {
            if (updatedCategory == null || string.IsNullOrWhiteSpace(updatedCategory.Name))
            {
                return false;
            }

            var category = db.Category.FirstOrDefault(c => c.Id == updatedCategory.Id);
            if (category == null)
            {
                return false;
            }

            category.Name = updatedCategory.Name;

            db.SaveChanges();
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var category = db.Category.Include(c => c.Books).FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return false;
            }

            if (category.Books.Any())
            {
                return false;
            }

            db.Category.Remove(category);
            db.SaveChanges();
            return true;
        }
    }
}

