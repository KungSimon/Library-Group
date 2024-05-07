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
            int authorId = CheckInput("Input author ID");
            Console.WriteLine("Input new name.");
            string title = Console.ReadLine();
            sender.UpdateAuthor(authorId, title);
        }

        public void DeleteAuthor()
        {
            int authorId = CheckInput("Input author ID");
            sender.DeleteAuthor(authorId);
        }

        public void GetAuthorById()
        {
            int authorId = CheckInput("Input author ID");
            sender.GetAuthorById(authorId);
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


