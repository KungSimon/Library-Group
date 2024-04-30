using Client.Objects;
using Client.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class mainMenu
    {
        
        HttpMessageSender sender = new HttpMessageSender();
       

        public void Run()
        {
            BookService bookService = new BookService();
            AuthorService authorService = new AuthorService();
            CategoryService categoryService = new CategoryService();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Books");
                Console.WriteLine("2. Authors");
                Console.WriteLine("3. Categories");
                Console.WriteLine("0. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        HandleBooks(bookService);
                        break;
                    case "2":
                        HandleAuthors(authorService);
                        break;
                    case "3":
                        HandleCategories(categoryService);
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        static void HandleBooks(BookService bookService)
        {
            while (true)
            {
                Console.WriteLine("Choose an option for books:");
                Console.WriteLine("1. Get all books");
                Console.WriteLine("2. Get book by ID");
                Console.WriteLine("3. Add a book");
                Console.WriteLine("4. Update a book");
                Console.WriteLine("5. Delete a book");
                Console.WriteLine("0. Back");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        bookService.PrintAllBooks();
                        break;
                    case "2":
                        Console.WriteLine("Enter the ID of the book:");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        sender.GetBookById(bookId);
                        break;
                    case "3":
                        bookService.AddBook();
                        break;
                    case "4":
                        bookService.UpdateBook();
                        break;
                    case "5":
                        bookService.DeleteBook();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        static void HandleAuthors(AuthorService authorService)
        {
            while (true)
            {
                Console.WriteLine("Choose an option for authors:");
                Console.WriteLine("1. Get all authors");
                Console.WriteLine("2. Get author by ID");
                Console.WriteLine("3. Add an author");
                Console.WriteLine("4. Update an author");
                Console.WriteLine("5. Delete an author");
                Console.WriteLine("0. Back");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        authorService.PrintAllAuthors();
                        break;
                    case "2":
                        Console.WriteLine("Enter the ID of the author you want to find:");
                        int authorId = Convert.ToInt32(Console.ReadLine());
                        sender.GetAuthorById(authorId);
                        break;
                    case "3":
                        authorService.AddAuthor();
                        break;
                    case "4":
                        authorService.UpdateAuthor();
                        break;
                    case "5":
                        authorService.DeleteAuthor();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        static void HandleCategories(CategoryService categoryService)
        {
            while (true)
            {
                Console.WriteLine("Choose an option for categories:");
                Console.WriteLine("1. Get all categories");
                Console.WriteLine("2. Find genre by id");
                Console.WriteLine("3. Add a category");
                Console.WriteLine("4. Update a category");
                Console.WriteLine("5. Delete a category");
                Console.WriteLine("0. Back");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        categoryService.PrintAllCategories();
                        break;
                    case "2":
                        Console.WriteLine("Enter the ID of the genre you want to find:");
                        int genreId = Convert.ToInt32(Console.ReadLine());
                        sender.GetAuthorById(genreId);
                        break;
                    case "3":
                        categoryService.AddCategory();
                        break;
                    case "4":
                        categoryService.UpdateCategory();
                        break;
                    case "5":
                        categoryService.DeleteCategory();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
