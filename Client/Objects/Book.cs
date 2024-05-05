using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Objects
{
    public class Book
    {
        public int Id;
        public string Title { get; set; }
        public int Pages { get; set; }
        public int ReleaseDate { get; set; }

        public Book(int id, string title, int pages, int releaseDate)
        {
            Id = id;
            Title = title;
            Pages = pages;
            ReleaseDate = releaseDate;
        }

        public Book(string title, int pages, int releaseDate)
        {
            Id = 0;
            Title = title;
            Pages = pages;
            ReleaseDate = releaseDate;
        }
        public Book() { }
    }
}
