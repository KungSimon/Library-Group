﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library_Group.Objects
{
    //Test
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public int Pages { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }

        public Book(int id, string title, int pages, DateTime releaseDate)
        {
            Id = id;
            Title = title;
            Pages = pages;
            ReleaseDate = releaseDate;
        }

        public Book() { }
    }
}
