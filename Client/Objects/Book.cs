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
        public DateTime ReleaseDate { get; set; }


        public Book(int id, string title, int pages, DateTime releaseDate)
        {
            Id = id;
            Title = title;
            Pages = pages;
            ReleaseDate = releaseDate;
        }

        public Book(string title, int pages, DateTime releaseDate)
        {
            Id = 0;
            Title = title;
            Pages = pages;
            ReleaseDate = releaseDate;
        }
        public Book() { }
    }
}
