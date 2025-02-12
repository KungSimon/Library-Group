﻿using Client.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    public class HttpMessageSender
    {
        //Change port in baseUrl to avoid changing Url in all functions
        private readonly string baseUrl = "https://localhost:7264/api/";

        //To get all books
        public List<Book> GetAllBooks()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseUrl + "book").Result;
            Console.WriteLine("Status code " + response.StatusCode);

            if(response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Book>>(json);
            }
            else
            {
                return null; 
            }
        }

        //To get all authors
        public List<Author> GetAllAuthors()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseUrl + "author").Result;
            Console.WriteLine("Status code " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Author>>(json);
            }
            else
            {
                return null;
            }
        }

        //To get all Categories

        public List<Category> GetAllCategories() 
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseUrl + "category").Result;
            Console.WriteLine("Status code " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Category>>(json);
            }
            else
            {
                return null;
            }
        }

        //To find a book by id
        public void GetBookById(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseUrl + "book/" + id).Result;
            Console.WriteLine("Status code " + (int)response.StatusCode + " : " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Book book = JsonConvert.DeserializeObject<Book>(result);
                Console.WriteLine("Id: " + book.Id + ", Title: " + book.Title + ", Pages: " + book.Pages + ", Release Date: " + book.ReleaseDate + ", Author: " + book.AuthorId + ", Category: " + book.CategoryId);
            }
        }

        //To find a author by id
        public void GetAuthorById(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseUrl + "author/" + id).Result;
            Console.WriteLine("Status code " + (int)response.StatusCode + " : " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Author author = JsonConvert.DeserializeObject<Author>(result);
                Console.WriteLine("Id: " + author.Id + ", Name: " + author.Name);
            }
        }

        //To find a category by id
        public void GetCategoryById(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseUrl + "category/" + id).Result;
            Console.WriteLine("Status code " + (int)response.StatusCode + " : " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Category category = JsonConvert.DeserializeObject<Category>(result);
                Console.WriteLine("Id: " + category.Id + ", Name: " + category.Name);
            }
        }

        //To add a book
        public void AddBook(string title, int pageCount, int dateTime, int authorId, int categoryId)                    
        {
            Book book = new Book(title, pageCount, dateTime, authorId, categoryId);
            string json = JsonConvert.SerializeObject(book);

            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(baseUrl + "book", httpContent).Result;
            Console.WriteLine("Status code: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(book.Title + " was successfully added!");
            }
            else { Console.WriteLine(book.Title + " was not added."); }
        }

        //To add a author
        public void AddAuthor(int id, string name)
        {
            Author author = new Author(id, name);
            string json = JsonConvert.SerializeObject(author);

            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(baseUrl + "author", httpContent).Result;
            Console.WriteLine("Status code: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(author.Name + " was successfully added!");
            }
            else { Console.WriteLine(author.Name + " was not added."); }
        }

        //To add a category
        public void AddCategory(int id, string name)
        {
            Category category = new Category(id, name);
            string json = JsonConvert.SerializeObject(category);

            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(baseUrl + "category", httpContent).Result;
            Console.WriteLine("Status code: " + response.StatusCode);
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
            HttpResponseMessage response = client.DeleteAsync(baseUrl + "book/" + id).Result;

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
            HttpResponseMessage response = client.DeleteAsync(baseUrl + "author/" + id).Result;

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
            HttpResponseMessage response = client.DeleteAsync(baseUrl + "category/" + id).Result;

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
        public void UpdateBook(int id, string title, int pageCount, int releaseDate)
        {
            Book book = new Book(id, title, pageCount, releaseDate);
            string json = JsonConvert.SerializeObject(book);

            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(baseUrl + "book/" + id, httpContent).Result;
            Console.WriteLine("Status code: " + response.StatusCode);
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
        public void UpdateAuthor(int id, string name)
        {
            Author author = new Author(id, name);
            string json = JsonConvert.SerializeObject(author);
            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(baseUrl + "author/" + id, httpContent).Result;
            Console.WriteLine("Status code: " + response.StatusCode);
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
        public void UpdateCategory(int id, string name)
        {
            Category category = new Category(id, name);
            string json = JsonConvert.SerializeObject(category);
            HttpClient client = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(baseUrl + "category/" + id, httpContent).Result;
            Console.WriteLine("Status code: " + response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Category with ID {id} successfully updated!");
            }
            else
            {
                Console.WriteLine($"Failed to update category with ID {id}.");
            }
        }


        public bool BookExists(int bookId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseUrl + "book/" + bookId).Result;

            return response.IsSuccessStatusCode;
        }

        public bool AuthorExists(int authorId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseUrl + "author/" + authorId).Result;

            return response.IsSuccessStatusCode;
        }

        public bool CategoryExists(int categoryId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(baseUrl + "category/" + categoryId).Result;

            return response.IsSuccessStatusCode;
        }
    }
}
