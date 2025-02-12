﻿using Client.Objects;
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
            sender.AddCategory(id, name);
        }

        public void UpdateCategory()
        {
            int categoryId = CheckInput("Input category ID");
            Console.WriteLine("Input new category name.");
            string title = Console.ReadLine();
            sender.UpdateCategory(categoryId, title);
        }

        public void DeleteCategory()
        {
            int categoryId = CheckInput("Input category ID");
            sender.DeleteCategory(categoryId);
        }

        public void GetCategoryById()
        {
            int categoryId = CheckInput("Input category ID");
            sender.GetCategoryById(categoryId);
        }


        private int CheckInput(string input)
        {
            while (true)
            {
                Console.WriteLine(input);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input, please enter a valid number.");
            }
        }
    }
}

