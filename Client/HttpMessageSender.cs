using Client.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class HttpMessageSender
    {
        //To get all books
        public void GetAllBooks()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:7093/api/books/all").Result;
            Console.WriteLine("Status code " + (int)response.StatusCode + " : " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(result);
                foreach (Book book in books)
                {
                    Console.WriteLine("Id: " + book.Id + ", Title: " + book.Title + ", Pages: " + book.Pages + ", Release Date: " + book.ReleaseDate);
                }
            }
        }

        //To get all authors
        public void GetAllAuthors()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:7093/api/author/all").Result;
            Console.WriteLine("Status code " + (int)response.StatusCode + " : " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                List<Author> authors = JsonConvert.DeserializeObject<List<Author>>(result);
                foreach (Author author in authors)
                {
                    Console.WriteLine("Id: " + author.Id + ", Name: " + author.Name);
                }
            }
        }

        //To get all Categories
        public void GetAllCategories()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:7093/api/category/all").Result;
            Console.WriteLine("Status code " + (int)response.StatusCode + " : " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(result);
                foreach (Category category in categories)
                {
                    Console.WriteLine("Id: " + category.Id + ", Name: " + category.Name);
                }
            }
        }

        //To find a book by id
        public void GetBookById(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:7093/api/book?id=" + id).Result;
            Console.WriteLine("Status code " + (int)response.StatusCode + " : " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                Book book = JsonConvert.DeserializeObject<Book>(result);
                Console.WriteLine("Id: " + book.Id + ", Title: " + book.Title + ", Pages: " + book.Pages + ", Release Date: " + book.ReleaseDate);
            }
        }

        //To find a author by id
        public void GetAuthorById(int id) 
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:7093/api/author?id=" + id).Result;
            Console.WriteLine("Status code " + (int)response.StatusCode + " : " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                Author author = JsonConvert.DeserializeObject<Author>(result);
                Console.WriteLine("Id: " + author.Id + ", Name: " + author.Name);
            }
        }

        //To find a category by id
        public void GetCategoryById(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:7093/api/category?id=" + id).Result;
            Console.WriteLine("Status code " + (int)response.StatusCode + " : " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                Category category = JsonConvert.DeserializeObject<Category>(result);
                Console.WriteLine("Id: " + category.Id + ", Name: " + category.Name);
            }
        }

        //To add a book
        public void AddBook()
        {
            Book book = new Book(33, "Lord of the rings", 3000, 2024);
            string json = JsonConvert.SerializeObject(book);

            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("https://localhost:7093/api/book/add", httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(book.Title + " was successfully added!");
            }
            else { Console.WriteLine(book.Title + " was not added."); }
        }

        //To add a author
        public void AddAuthor()
        {
            Author author = new Author(33, "J.R.R. Tolkien");
            string json = JsonConvert.SerializeObject(author);

            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("https://localhost:7093/api/author/add", httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(author.Name + " was successfully added!");
            }
            else { Console.WriteLine(author.Name + " was not added."); }
        }

        //To add a category
        public void AddCategory()
        {
            Category category = new Category(33, "Fantasy");
            string json = JsonConvert.SerializeObject(category);

            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("https://localhost:7093/api/category/add", httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(category.Name + " was successfully added!");
            }
            else { Console.WriteLine(category.Name + " was not added."); }
        }

        //To delete a book
        public void DeleteBook(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync($"https://localhost:7093/api/book/delete/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Book with ID {id} successfully deleted!");
            }
            else
            {
                Console.WriteLine($"Failed to delete book with ID {id}.");
            }
        }

        //To delete a author
        public void DeleteAuthor(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync($"https://localhost:7093/api/author/delete/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Author with ID {id} successfully deleted!");
            }
            else
            {
                Console.WriteLine($"Failed to delete author with ID {id}.");
            }
        }

        //To delete a category
        public void DeleteCategory(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync($"https://localhost:7093/api/category/delete/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Category with ID {id} successfully deleted!");
            }
            else
            {
                Console.WriteLine($"Failed to delete category with ID {id}.");
            }
        }

        //To update a book
        public void UpdateBook(int id, Book updatedBook)
        {
            string json = JsonConvert.SerializeObject(updatedBook);
            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync($"https://localhost:7093/api/book/update/{id}", httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Book with ID {id} successfully updated!");
            }
            else
            {
                Console.WriteLine($"Failed to update book with ID {id}.");
            }
        }

        //To update a author
        public void UpdateAuthor(int id, Author updatedAuthor)
        {
            string json = JsonConvert.SerializeObject(updatedAuthor);
            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync($"https://localhost:7093/api/author/update/{id}", httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Author with ID {id} successfully updated!");
            }
            else
            {
                Console.WriteLine($"Failed to update author with ID {id}.");
            }
        }

        //To update a category
        public void UpdateCategory(int id, Category updatedCategory)
        {
            string json = JsonConvert.SerializeObject(updatedCategory);
            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync($"https://localhost:7093/api/category/update/{id}", httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Category with ID {id} successfully updated!");
            }
            else
            {
                Console.WriteLine($"Failed to update category with ID {id}.");
            }
        }
    }
}
