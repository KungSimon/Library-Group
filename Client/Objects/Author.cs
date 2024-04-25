using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Objects
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Author(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Author()
        {
        }
    }
}
