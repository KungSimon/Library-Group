using Client.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class BookService
    {
        HttpMessageSender sender = new HttpMessageSender();

        public void PrintAllBooks()
        {
            List<Book> books = sender.GetAllBooks();
            if (books == null)
            {
                Console.WriteLine("Something went wrong!");
            }
            else
            {
                foreach (Book book in books)
                {
                    Console.WriteLine("Id: " + book.Id + ", Title: " + book.Title +
                        ", Pages: " + book.Pages + ", Releasedate: " + book.ReleaseDate + ", Author: " + book.AuthorId + ", Category: " + book.CategoryId);
                }
            }
        }

        public void AddBook()
        {
            Console.WriteLine("Input name of the book:");
            string name = Console.ReadLine();

            int pages = CheckInput("Input Pagecount");
            int releasedate = CheckInput("Input Releasedate (Year)");
            int authorId = CheckInput("Input Author ID");
            int categoryId = CheckInput("Input Category ID");

            sender.AddBook(name, pages, releasedate, authorId, categoryId);
        }

        public void UpdateBook()
        {
            Console.WriteLine("Input id of book to edit.");
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
            Console.WriteLine("Input new title.");
            string title = Console.ReadLine();
            Console.WriteLine("Input new amount of pages.");
            int pageCount;
            int releasedate;
            try
            {
                pageCount = int.Parse(Console.ReadLine());
                try
                {
                    Console.WriteLine("Input new releasedate");
                    releasedate = int.Parse(Console.ReadLine());
                    sender.UpdateBook(id, title, pageCount, releasedate);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("That was not a date");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("That was not a number.");
                return;
            }
        }

        public void DeleteBook()
        {
            Console.WriteLine("Enter the id of the book you want to remove: ");
            int id;
            try
            {
                id = int.Parse(Console.ReadLine());
                sender.DeleteBook(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("That was not a number.");
                return;
            }
        }

        public void GetBookById()
        {
            Console.WriteLine("Enter the ID of the book:");
            int bookId = Convert.ToInt32(Console.ReadLine());
            sender.GetBookById(bookId); 
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
