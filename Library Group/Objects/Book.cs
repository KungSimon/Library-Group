﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library_Group.Objects
{
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
  
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public Book(string title, int pages, DateTime releaseDate)
        {
            Title = title;
            Pages = pages;
            ReleaseDate = releaseDate;
        }

        public Book() { }
    }
}
