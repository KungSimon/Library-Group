using Client.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class CategoryService
    {
        HttpMessageSender sender = new HttpMessageSender();

        public void PrintAllCategories()
        {
            List<Category> categories = sender.GetAllCategories();
            if (categories == null)
            {
                Console.WriteLine("Something went wrong!");
            }
            else
            {
                foreach (Category category in categories)
                {
                    Console.WriteLine("Id: " + category.Id + ", Name: " + category.Name);
                }
            }
        }

        public void AddCategory()
        {
            int id = 0;
            Console.WriteLine("Input Name of the category: ");
            string name = Console.ReadLine();
            sender.AddAuthor(id, name);
        }

        public void UpdateCategory()
        {
            Console.WriteLine("Input id of category to edit.");
            int id;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("That was not a number.");
                return;
            }
            Console.WriteLine("Input new category name.");
            string title = Console.ReadLine();
            sender.UpdateCategory(id, title);
        }

        public void DeleteCategory()
        {
            Console.WriteLine("Enter the id of the category you want to remove: ");
            int id;
            try
            {
                id = int.Parse(Console.ReadLine());
                sender.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("That was not a number.");
                return;
            }
        }

        public void GetCategoryById()
        {
            Console.WriteLine("Enter the ID of the category:");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            sender.GetCategoryById(categoryId);
        }
    }
}

