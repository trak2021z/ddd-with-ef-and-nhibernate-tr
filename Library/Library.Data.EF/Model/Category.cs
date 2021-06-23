using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.EF.Model
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public virtual IReadOnlyCollection<Book> Books { get; }

        protected Category()
        {

        }

        public Category(string name)
        {
            Name = name ?? throw new NullReferenceException(nameof(name));
        }
    }
}
