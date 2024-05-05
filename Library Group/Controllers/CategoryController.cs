using Library_Group.Objects;
using Library_Group.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Group.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAllCategories()
        {
            var categories = categoryService.GetAllCategories();
            if (categories.Count == 0)
            {
                return NoContent();
            }
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = categoryService.GetCategoryById(id);

            if (category != null)
            {
                return Ok(category);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool success = categoryService.AddCategory(category);
            if (success)
            {
                return Ok();
            }
            return BadRequest("Failed to add the category.");
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest("Mismatched category ID.");
            }

            bool success = categoryService.UpdateCategory(category);
            if (success)
            {
                return Ok();
            }
            return BadRequest("Failed to update the category.");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var category = categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound("Category was not found.");
            }

            if (category.Books.Any())
            {
                return Conflict("Cannot delete category because it has books associated with it.");
            }

            bool success = categoryService.DeleteCategory(id);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
