using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.EF.Model
{
    public class Borrowing : Entity
    {
        public virtual Member CurrentBorrower { get; private set; }
        public virtual Book Book { get; private set; }
        public DateTime Date { get; private set; }

        protected Borrowing()
        {
        }

        public Borrowing(Member currentBorrower, Book book, DateTime date)
            : this()
        {
            CurrentBorrower = currentBorrower;
            Book = book;
            Date = date;
        }
    }
}
