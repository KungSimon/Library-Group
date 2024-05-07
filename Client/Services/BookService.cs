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
            bool success = true;
            Console.WriteLine("Input name of the book:");
            string name = Console.ReadLine();
            int pages = CheckInput("Input Pagecount");
            int releasedate = CheckInput("Input Releasedate (Year)");
            int authorId = CheckInput("Input Author ID");
            if (sender.AuthorExists(authorId) == false)
            {
                Console.WriteLine("There is no author with that id.");
                return;
            }
            int categoryId = CheckInput("Input Category ID");

            if (sender.CategoryExists(authorId) == false)
            {
                Console.WriteLine("There is no category with that id.");
                return;
            }
            sender.AddBook(name, pages, releasedate, authorId, categoryId);
        }



        public void UpdateBook()
        {
            int bookId = CheckInput("Input book id of the book you want to change.");
            Console.WriteLine("Input new title.");
            string title = Console.ReadLine();
            int pageCount = CheckInput("Enter the new amount of pages");
            int releasedate = CheckInput("Enter the new release date.");
            sender.UpdateBook(bookId, title, pageCount, releasedate);
        }
        

        public void DeleteBook()
        {
            int bookId = CheckInput("Enter the id of the book you want to remove: ");
            sender.DeleteBook(bookId);
        }

        public void GetBookById()
        {
            int bookId = CheckInput("Input book ID");
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
