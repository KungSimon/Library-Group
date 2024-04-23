using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library_Group.Objects
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Book> AuthorBooks { get; set; } = new List<Book>();

        public Author(string name)
        {
            Name = name;
        }

        public Author() { }
    }
}
