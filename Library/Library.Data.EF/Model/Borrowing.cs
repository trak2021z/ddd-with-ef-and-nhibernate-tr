using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.EF.Model
{
    public class Borrowing : Entity
    {
        public virtual Member Member { get; }
        public virtual Book Book { get; }
        public DateTime Date { get; }

        protected Borrowing()
        {
        }

        public Borrowing(Member member, Book book, DateTime date)
            : this()
        {
            Member = member;
            Book = book;
            Date = date;
        }
    }
}
