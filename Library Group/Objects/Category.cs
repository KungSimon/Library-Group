using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library_Group.Objects
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        public List<Book> CategoryBooks { get; set; } = new List<Book>();

        public Category(string name)
        {
            Name = name;
        }

        public Category() { }
    }
}
