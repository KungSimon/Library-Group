using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        public int ReleaseDate { get; set; }

        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public Book(string title, int pages, int releaseDate)
        {
            Title = title;
            Pages = pages;
            ReleaseDate = releaseDate;
        }

        public Book() { }
    }
}
