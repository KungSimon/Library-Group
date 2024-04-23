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

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Category() { }
    }
}
