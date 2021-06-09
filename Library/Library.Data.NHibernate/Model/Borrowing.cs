using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.NHibernate.Model
{
    public class Borrowing : Entity
    {
        public virtual Member CurrentBorrower { get; }
        public virtual Book Book { get; }
        public DateTime Date { get; }

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
