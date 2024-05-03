using Client.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class AuthorService
    {
        HttpMessageSender sender = new HttpMessageSender();

        public void PrintAllAuthors()
        {
            List<Author> authors = sender.GetAllAuthors();
            if (authors == null)
            {
                Console.WriteLine("Something went wrong!");
            }
            else
            {
                foreach (Author author in authors)
                {
                    Console.WriteLine("Id: " + author.Id + ", Name: " + author.Name);
                }
            }
        }

        public void AddAuthor()
        {
            int id = 0;
            Console.WriteLine("Input Name of the author: ");
            string name = Console.ReadLine();
            sender.AddAuthor(id, name);
        }

        public void UpdateAuthor()
        {
            Console.WriteLine("Input id of author to edit.");
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
            Console.WriteLine("Input new name.");
            string title = Console.ReadLine();
            sender.UpdateAuthor(id, title);
        }

        public void DeleteAuthor()
        {
            Console.WriteLine("Enter the id of the author you want to remove: ");
            int id;
            try
            {
                id = int.Parse(Console.ReadLine());
                sender.DeleteAuthor(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("That was not a number.");
                return;
            }
        }

        public void GetAuthorById()
        {
            Console.WriteLine("Enter the ID of the author:");
            int authorId = Convert.ToInt32(Console.ReadLine());
            sender.GetAuthorById(authorId);
        }
    }
}


