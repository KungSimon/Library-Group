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
                        ", Pages: " + book.Pages + ", Releasedate: " + book.ReleaseDate);
                }
            }
        }

        public void AddBook()
        {
            int id = 0;
            Console.WriteLine("Input Name of the book: ");
            string name = Console.ReadLine();
            Console.WriteLine("Input Pagecount");
            int pages;
            DateTime releasedate;
            try
            {
                pages = int.Parse(Console.ReadLine());
                try
                {
                    Console.WriteLine("Input Releasedate");
                    releasedate = DateTime.Parse(Console.ReadLine());
                    sender.AddBook(id, name, pages, releasedate);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("That was not a date");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("That was not a number");
                return;
            }
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
            DateTime releasedate;
            try
            {
                pageCount = int.Parse(Console.ReadLine());
                try
                {
                    Console.WriteLine("Input new releasedate");
                    releasedate = DateTime.Parse(Console.ReadLine());
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
    }
}
