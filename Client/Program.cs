namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpMessageSender sender = new HttpMessageSender();

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
                        HandleBooks(sender);
                        break;
                    case "2":
                        HandleAuthors(sender);
                        break;
                    case "3":
                        HandleCategories(sender);
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

        static void HandleBooks(HttpMessageSender sender)
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
                        sender.GetAllBooks();
                        break;
                    case "2":
                        Console.WriteLine("Enter the ID of the book:");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        sender.GetBookById(bookId);
                        break;
                    case "3":
                        sender.AddBook();
                        break;
                    case "4":
                        Console.WriteLine("Enter the ID of the book to update:");
                        int editBookId = Convert.ToInt32(Console.ReadLine());
                        sender.UpdateBook(editBookId);
                        break;
                    case "5":
                        Console.WriteLine("Enter the ID of the book to delete:");
                        int deleteBookId = Convert.ToInt32(Console.ReadLine());
                        sender.DeleteBook(deleteBookId);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        static void HandleAuthors(HttpMessageSender sender)
        {
            while (true)
            {
                Console.WriteLine("Choose an option for authors:");
                Console.WriteLine("1. Get all authors");
                Console.WriteLine("2. Add an author");
                Console.WriteLine("3. Update an author");
                Console.WriteLine("4. Delete an author");
                Console.WriteLine("0. Back");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        sender.GetAllAuthors();
                        break;
                    case "2":
                        sender.AddAuthor();
                        break;
                    case "3":
                        Console.WriteLine("Enter the ID of the author to update:");
                        int editAuthorId = Convert.ToInt32(Console.ReadLine());
                        sender.UpdateAuthor(editAuthorId);
                        break;
                    case "4":
                        Console.WriteLine("Enter the ID of the author to delete:");
                        int deleteAuthorId = Convert.ToInt32(Console.ReadLine());
                        sender.DeleteAuthor(deleteAuthorId);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        static void HandleCategories(HttpMessageSender sender)
        {
            while (true)
            {
                Console.WriteLine("Choose an option for categories:");
                Console.WriteLine("1. Get all categories");
                Console.WriteLine("2. Add a category");
                Console.WriteLine("3. Update a category");
                Console.WriteLine("4. Delete a category");
                Console.WriteLine("0. Back");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        sender.GetAllCategories();
                        break;
                    case "2":
                        sender.AddCategory();
                        break;
                    case "3":
                        Console.WriteLine("Enter the ID of the category to update:");
                        int editCategoryId = Convert.ToInt32(Console.ReadLine());
                        sender.UpdateCategory(editCategoryId);
                        break;
                    case "4":
                        Console.WriteLine("Enter the ID of the category to delete:");
                        int deleteCategoryId = Convert.ToInt32(Console.ReadLine());
                        sender.DeleteCategory(deleteCategoryId);
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
